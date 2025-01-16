namespace Stage2.Figures
{
    public class Circle : Figure, IMovable
    {
        public double Speed { get; set; }

        public Circle(double speed) : base("Круг", TaskType.ClearPath)
        {
            Speed = speed;
        }

        public override void PerformTask()
        {
            System.Console.WriteLine($"{Name} очищает путь от препятствий.");
            System.Console.WriteLine($"Текущая скорость: {Speed:F2}.");
        }

        public void Move()
        {
            System.Console.WriteLine($"{Name} движется со скоростью {Speed:F2}.\n");
        }

        public void UpdateSpeed(double newSpeed)
        {
            Speed = newSpeed;
        }

        public override string ImagePath => "avares://Stage2.AvaloniaApp/Images/circle.png";
    }
}
