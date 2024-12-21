namespace Stage2.Figures;

public class Rectangle : Figure, IBuildable
{
    public Rectangle() : base("Прямоугольник", TaskType.BuildBridge) { }

    public override void PerformTask()
    {
        System.Console.WriteLine($"{Name} строит мосты через препятствия.");
    }

    public void Build()
    {
        System.Console.WriteLine($"{Name} соединяет регионы, создавая мосты.\n");
    }
}
