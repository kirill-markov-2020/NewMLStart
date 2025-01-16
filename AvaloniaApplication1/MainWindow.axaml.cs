using Avalonia.Controls;
using Avalonia.Interactivity;
using Stage2.Figures;
using System.Collections.ObjectModel;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Figure> Figures { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация списка фигур
            Figures = new ObservableCollection<Figure>
            {
                new Circle(10),
                new Square(),
                new Rectangle(),
                new Triangle()
            };

            // Устанавливаем DataContext для привязки
            DataContext = this;
        }

        private void PerformTaskButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var figure in Figures)
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
            }
        }
    }
}
