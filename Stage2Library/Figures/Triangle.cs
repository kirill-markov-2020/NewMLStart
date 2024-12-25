namespace Stage2.Figures
{
    public class Triangle : Figure, IBuildable
    {
        public Triangle() : base("Треугольник", TaskType.Reinforce) { }

        public override void PerformTask()
        {
            System.Console.WriteLine($"{Name} укрепляет конструкции.");
        }

        public void Build()
        {
            System.Console.WriteLine($"{Name} использует углы для укрепления конструкций.\n");
        }

        public override string ImagePath => "avares://Stage2.AvaloniaApp/Images/triangle.png";
    }
}
