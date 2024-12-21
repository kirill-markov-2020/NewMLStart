namespace Stage2.Figures;

public class Triangle : Figure, IBuildable
{
    public Triangle() : base("Треугольник", TaskType.Reinforce) { }

    public override void PerformTask()
    {
        System.Console.WriteLine($"{Name} укрепляет конструкции местных шахт.");
    }

    public void Build()
    {
        System.Console.WriteLine($"{Name} использует свои углы для укрепления конструкций.");
    }
}
