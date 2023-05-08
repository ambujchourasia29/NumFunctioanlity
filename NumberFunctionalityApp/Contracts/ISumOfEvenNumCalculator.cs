using ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFunctionalityApp.Contracts
{
    public interface ISumOfEvenNumberProvider
    {
        int GetSumOfEvenNumbers(List<int> numbers);
    }
}
