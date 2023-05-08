using ConsoleApp;
using ConsoleApp.Contracts;
using NLog;
using NumberFunctionalityApp.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Unity;

namespace NumberFunctionalityApp
{
    internal class Program
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<ISumOfNumberProvider, SumOfNumberProvider>();
            container.RegisterType<ISumOfEvenNumberProvider, SumOfEvenNumberProvider>();
            container.RegisterType<IParser, TextFileParser>();

            const string fileName = "Numbers (homework task - desktop developer .NET).txt";
            Assembly assembly = Assembly.GetExecutingAssembly();
            string workingDirectory = Path.GetDirectoryName(assembly.Location);

            try
            {
                List<int> numbers = container.Resolve<IParser>().GetNumberList(Path.Combine(workingDirectory, "Resources", fileName));

                logger.Info($"Sum of numbers:{container.Resolve<ISumOfNumberProvider>().GetSumOfNumbers(numbers)}");
                logger.Info($"Sum of Even Numbers:{container.Resolve<ISumOfEvenNumberProvider>().GetSumOfEvenNumbers(numbers)}");
            }
            catch(ArgumentNullException ex)
            {
                logger.Error($"Exception occured: {ex.Message}");
            }
            catch (FileNotFoundException ex)
            {
                logger.Error($"Exception occured: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.Error($"Exception occured: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
