using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using Serilog;
using Stage2.Figures;

namespace Stage2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filename = "Stage1.json";

            string configFilePath = "config.json";

            // Загрузка конфигурации
            int delay = LoadOrCreateConfig(configFilePath);
            if (!File.Exists(filename))
            {
                var content = @"{
                                    ""FirstName"": ""Кирилл"",
                                    ""LastName"": ""Марков""
                                }";
                File.WriteAllText(filename, content);
            }
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(filename).Build();
            string firstName = configuration["FirstName"];
            string lastName = configuration["LastName"];
            int N = firstName.Length;
            int L = lastName.Length;

            int[] oddNumbers = new int[] { 5, 7, 9, 11, 13, 15, 17, 19 };
            double[,] k = new double[8, 13];
            double[] randomValues = new double[13];
            Random random = new Random();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.File("Logs/trace.log", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose)
                .WriteTo.File("Logs/debug.log", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                .WriteTo.File("Logs/info.log", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
                .WriteTo.File("Logs/warning.log", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning)
                .WriteTo.File("Logs/error.log", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)
                .WriteTo.File("Logs/critical.log", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Fatal)
                .CreateLogger();

            var logger = Log.ForContext<Program>();

            logger.Information("Программа запущена.");

            for (int i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = Math.Round(random.NextDouble() * 27.0 - 12.0, 2);
            }

            for (int i = 0; i < oddNumbers.Length; i++)
            {
                for (int j = 0; j < randomValues.Length; j++)
                {
                    double x = randomValues[j];
                    if (oddNumbers[i] == 9)
                    {
                        k[i, j] = Math.Sin(Math.Sin(Math.Pow((x / (x + 0.5)), x)));
                        logger.Verbose($"Verbose: k[{i}, {j}] = {k[i, j]}");
                    }
                    else if (oddNumbers[i] == 5 || oddNumbers[i] == 7 || oddNumbers[i] == 11 || oddNumbers[i] == 15)
                    {
                        k[i, j] = Math.Pow((0.5 / Math.Tan(2 * x) + (2 / 3)), Math.Pow(x, 1 / 9));
                        logger.Debug($"Debug: k[{i}, {j}] = {k[i, j]}");
                    }
                    else
                    {
                        k[i, j] = Math.Pow(Math.Tan(((Math.Exp(1 - x / Math.PI)) / 3) / 4), 3);
                        logger.Information($"Info: k[{i}, {j}] = {k[i, j]}");
                    }
                }
            }

            int I = N % 6;
            int J = L % 13;

            double minimalElement = k[I, 0];
            logger.Information($"Minimal element at k[{I}, 0] = {minimalElement}");

            for (int col = 0; col < oddNumbers.Length; col++)
            {
                if (k[I, col] < minimalElement)
                {
                    minimalElement = k[I, col];
                }
            }

            double sum = 0;
            for (int row = 0; row < k.GetLength(0); row++)
            {
                sum += k[row, J];
            }
            double average = sum / k.GetLength(0);
            double itog = average + minimalElement;
           
            logger.Information($"Результат вычислений: {itog:F4}");



            logger.Information("Программа завершена.");


            Log.CloseAndFlush();
            Figure[] figures = {
                new Circle(itog),      
                new Triangle(),
                new Square(),
                new Rectangle()
            };

            Console.WriteLine("Фигуры начинают выполнять свои задачи...\n");

            while (true) 
            {
                foreach (var figure in figures)
                {
                    figure.PerformTask();

                    if (figure is IMovable movable)
                    {
                        movable.Move();
                    }

                    if (figure is IBuildable buildable)
                    {
                        buildable.Build();
                    }

                    Console.WriteLine();

                    
                    Thread.Sleep(2000);
                }

                
            }
            static int LoadOrCreateConfig(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    var defaultConfig = @"{
                        ""Settings"": {
                            ""Delay"": 2000
                        }
                    }";
                    File.WriteAllText(filePath, defaultConfig);
                    Console.WriteLine($"Создан конфигурационный файл с задержкой по умолчанию: 2000 мс.");
                }

                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(filePath)
                    .Build();

                string delayValue = configuration["Settings:Delay"];

                if (int.TryParse(delayValue, out int delay) && delay > 0)
                {
                    Console.WriteLine($"Загружена задержка из конфигурационного файла: {delay} мс.");
                    return delay;
                }
                else
                {
                    Console.WriteLine("Ошибка в конфигурационном файле. Устанавливается задержка по умолчанию: 2000 мс.");
                    return 2000;
                }
            }
        }
    }
}
