namespace Stage2.Figures;

public class Square : Figure, IBuildable
{
    public Square() : base("Квадрат", TaskType.CreateStructures) { }

    public override void PerformTask()
    {
        System.Console.WriteLine($"{Name} создает прочные структуры на равнинах.");
    }

    public void Build()
    {
        System.Console.WriteLine($"{Name} строит устойчивые конструкции на равнинах.\n");
    }
}
