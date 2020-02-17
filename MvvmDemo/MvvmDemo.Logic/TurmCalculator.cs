using System;
using System.Collections.Generic;

namespace MvvmDemo.Logic
{
    public interface ITurmCalculator
    {
        IEnumerable<ResultRow> Calculate(int baseValue, int height);
    }

    public class TurmCalculator : ITurmCalculator
    {
        public IEnumerable<ResultRow> Calculate(int baseValue, int height)
        {
            if (height < 2)
            {
                throw new ArgumentException("Must be >= 2", nameof(height));
            }

            var currentResult = baseValue;

            // Multiplication
            for (var i = 0; i < height; i++)
            {
                yield return new ResultRow
                {
                    BaseValue = currentResult,
                    Operator = '*',
                    Operand = i + 2,
                    Result = currentResult *= (i + 2)
                };
            }

            // Division
            for (var i = 0; i < height; i++)
            {
                yield return new ResultRow
                {
                    BaseValue = currentResult,
                    Operator = '/',
                    Operand = i + 2,
                    Result = currentResult /= (i + 2)
                };
            }
        }
    }
}
