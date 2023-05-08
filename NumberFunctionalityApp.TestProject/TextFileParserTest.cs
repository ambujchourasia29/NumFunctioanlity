using ConsoleApp;
using ConsoleApp.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFunctionalityApp.TestProject
{
    public class TextFileParserTest
    {
        IParser parser;
        public TextFileParserTest()
        {
            parser = new TextFileParser();
        }

        [Fact]
        public void FilePathIsNull()
        {
            //Arrange
            string filePath = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                parser.GetNumberList(filePath);
            });
        }

        [Fact]
        public void FilePathNotExist()
        {
            //Arrange
            string filePath = @"C:\Test\file.txt";

            //Assert
            Assert.Throws<FileNotFoundException>(() =>
            {
                //Act
                parser.GetNumberList(filePath);
            });

        }
    }
}
