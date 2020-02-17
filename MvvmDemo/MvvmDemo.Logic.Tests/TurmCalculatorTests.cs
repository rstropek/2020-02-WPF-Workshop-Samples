using System;
using System.Linq;
using Xunit;

namespace MvvmDemo.Logic.Tests
{
    public class TurmCalculatorTests
    {
        [Fact]
        public void SimpleTurm()
        {
            // Prepare
            var calculator = new TurmCalculator();

            // Execute
            var result = calculator.Calculate(2, 2);

            /*
             *  2 * 2 = 4
             *  4 * 3 = 12
             * 12 / 2 = 6
             *  6 / 3 = 2
             */

            // Check
            Assert.Equal(result.First().BaseValue, result.Last().Result);
            Assert.Equal(4, result.Count());
            // ...
        }

        [Fact]
        public void InvalidHeightArgument()
        {
            Assert.Throws<ArgumentException>(
                () => new TurmCalculator().Calculate(2, 1).ToArray());
        }
    }
}
