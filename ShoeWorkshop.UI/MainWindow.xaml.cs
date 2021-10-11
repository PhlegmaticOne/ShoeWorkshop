using System.Windows;

namespace ShoeWorkshop.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow(object obj)
        {
            InitializeComponent();
            DataContext = obj;
        }
    }
}
