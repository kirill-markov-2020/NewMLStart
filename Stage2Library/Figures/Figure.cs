namespace Stage2.Figures
{
    public abstract class Figure
    {
        
        public TaskType Task { get; set; }

        protected Figure(string name, TaskType task)
        {
            Name = name;
            Task = task;
        }

        public abstract void PerformTask();
        public string Name { get; set; }
        public virtual string ImagePath { get; }

    }
}
