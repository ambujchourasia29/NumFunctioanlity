using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Contracts;
using NLog;

namespace ConsoleApp
{
    public class TextFileParser : IParser
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public List<int> GetNumberList(string filePath)
        {
            List<int> numbers = new List<int>();
                numbers = Parse(filePath);
            return numbers;
        }

        private static List<int> Parse(string filePath)
        {
            List<int> numbers;

            if (filePath == null)
                throw new ArgumentNullException(nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not exists at '{filePath}'");

            string[] splittedText = File.ReadAllText(filePath).Split(',');
            numbers = splittedText.Select(x =>
            {
                bool isParsed = int.TryParse(x, out int result);
                if (!isParsed)
                    logger.Error($"{x} is not a number");
                return new { result, isParsed };
            })
            .Where(x => x.isParsed)
            .Select(x => x.result).ToList<int>();
            return numbers;
        }
    }
}
