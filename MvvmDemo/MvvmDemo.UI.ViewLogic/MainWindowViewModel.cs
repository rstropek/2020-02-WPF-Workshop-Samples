using MvvmDemo.Logic;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MvvmDemo.UI.ViewLogic
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly ITurmCalculator calculator;

        public int BaseValue { get; set; }

        private int height;
        public int Height
        {
            get => height;
            set
            {
                height = value;
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        private int highestValue;
        public int HighestValue
        {
            get => highestValue;
            set => SetProperty(ref highestValue, value);
        }

        public ObservableCollection<ResultRow> Results { get; }
            = new ObservableCollection<ResultRow>();

        public DelegateCommand CalculateCommand { get; }

        public MainWindowViewModel(ITurmCalculator calculator)
        {
            this.calculator = calculator;
            CalculateCommand = new DelegateCommand(
                () => Calculate(),
                () => Height >= 2);
        }

        private void Calculate()
        {
            if (Height < 2)
            {
                // It doesn't make sense to calculate a Turm
                // with height < 2. Ignore call.
                return;
            }

            var result = calculator.Calculate(BaseValue, Height).ToList();

            if (result.Count > 0)
            {
                HighestValue = result.Max(rr => rr.Result);
            }

            Results.Clear();
            foreach(var item in result)
            {
                Results.Add(item);
            }
        }
    }
}
