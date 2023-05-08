using NLog;
using NumberFunctionalityApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberFunctionalityApp
{
    public class SumOfEvenNumberProvider : ISumOfEvenNumberProvider
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public int GetSumOfEvenNumbers(List<int> numbers)
        {
            int sum = 0;
            if(numbers == null)
                throw new ArgumentNullException("List of numbers is Null.");

            sum = numbers.Sum(num => num % 2 == 0 ? num : 0);
            return sum;
        }
    }
}