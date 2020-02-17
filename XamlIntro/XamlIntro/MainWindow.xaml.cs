using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlIntro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string pathData;
        public string PathData
        {
            get => pathData;
        }

        public MainWindow()
        {
            DataContext = this;

            var sb = new StringBuilder();
            sb.Append("M 10,10 ");
            sb.Append("H 150 ");
            sb.Append("V 150 ");
            sb.Append("H 10 ");
            sb.Append("Z");
            pathData = sb.ToString();
        }
    }
}
