using ConsoleApp.Contracts;
using NLog;
using NumberFunctionalityApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SumOfNumberProvider : ISumOfNumberProvider
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public int GetSumOfNumbers(List<int> numbers)
        {
            int sum = 0;
            if (numbers == null)
                throw new ArgumentNullException("List of numbers is NULL.");

            sum = numbers.Sum(num => num);
            return sum;
        }
    }
}
