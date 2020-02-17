using MvvmDemo.Logic;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace MvvmDemo.UI.ViewLogic.Tests
{
    public class MainWindowViewModelTests
    {
        [Fact]
        public void TestCalculateResults()
        {
            var calculatorMock = new Mock<ITurmCalculator>();
            calculatorMock.Setup(m => m.Calculate(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(Array.Empty<ResultRow>())
                .Verifiable();

            var vm = new MainWindowViewModel(calculatorMock.Object)
            {
                BaseValue = 2,
                Height = 3
            };

            vm.CalculateCommand.Execute();

            calculatorMock.Verify(m => m.Calculate(2, 3), Times.Once);
        }

        [Fact]
        public void TestCalculateWithTooLowHeight()
        {
            var vm = new MainWindowViewModel(Mock.Of<ITurmCalculator>())
            {
                BaseValue = 2,
                Height = 1
            };

            Assert.False(vm.CalculateCommand.CanExecute());

            vm.Height = 3;
            Assert.True(vm.CalculateCommand.CanExecute());
        }


        [Fact]
        public void TestHighestValue()
        {
            var calculatorMock = new Mock<ITurmCalculator>();
            calculatorMock.Setup(m => m.Calculate(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new[] { new ResultRow { BaseValue = 2, Operator = '*', Operand = 3, Result = 99 } });

            var vm = new MainWindowViewModel(calculatorMock.Object)
            {
                BaseValue = 2,
                Height = 3
            };

            var propertyChangedCalled = false;
            vm.PropertyChanged += (_, ea)
                => propertyChangedCalled = ea.PropertyName == nameof(MainWindowViewModel.HighestValue);
            vm.CalculateCommand.Execute();

            Assert.True(propertyChangedCalled);
            Assert.Equal(99, vm.HighestValue);
        }
    }
}
