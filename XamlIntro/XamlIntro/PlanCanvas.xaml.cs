using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
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
    public class Component : BindableBase
    {
        private double x;
        public double X
        {
            get => x;
            set => SetProperty(ref x, value);
        }

        public double Y { get; set; }
        public double Angle { get; set; }
        public double Length { get; set; }

        private double height = 20;
        public double Height
        {
            get => height;
            set => SetProperty(ref height, value);
        }
    }

    public class ComponentToThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Component c)
            {
                return new Thickness(c.X, c.Y, 0, 0);
            }

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class PlanCanvas : UserControl
    {
        public ObservableCollection<Component> Components { get; }
            = new ObservableCollection<Component>();

        public PlanCanvas()
        {
            InitializeComponent();
            DataContext = this;

            Components.Add(new Component { X = 0, Y = 50, Angle = 0.2, Length = 100 });
            Components.Add(new Component { X = 100, Y = 65, Angle = -0.2, Length = 75 });
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Debugger.Break();
        }
    }
}
