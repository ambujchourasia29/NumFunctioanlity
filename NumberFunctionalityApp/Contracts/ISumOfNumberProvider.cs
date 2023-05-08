using ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFunctionalityApp.Contracts
{
    public interface ISumOfNumberProvider
    {
        int GetSumOfNumbers(List<int> numbers);
    }
}
