using MvvmDemo.Logic;
using MvvmDemo.UI.ViewLogic;
using System.Windows;

namespace MvvmDemo.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new TurmCalculator());
        }
    }
}
