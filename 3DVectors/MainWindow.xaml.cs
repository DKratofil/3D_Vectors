using _3DVectors.ViewModels;
using System.Windows;

namespace _3DVectors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new VectorViewModel();
        }
    }
}
