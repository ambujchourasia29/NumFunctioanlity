using ConsoleApp;
using ConsoleApp.Contracts;
using NumberFunctionalityApp.Contracts;

namespace NumberFunctionalityApp.TestProject
{
    public class SumOfNumberProviderTest
    {
        ISumOfNumberProvider provider;
        List<int>? numbers;
        public SumOfNumberProviderTest()
        {
            provider = new SumOfNumberProvider();
        }

        [Fact]
        public void EmptyNumberList()
        {
            //Arrange
            numbers = new List<int>();

            //Act
            int actual = provider.GetSumOfNumbers(numbers);

            //Assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void NullList()
        {
            //Arrange

            //Assert
            Assert.Throws<ArgumentNullException>(() => 
            {
                //Act
                provider.GetSumOfNumbers(null);
            });

        }

        [Fact]
        public void WithInvalidCharInNumberList()
        {
            //Arrange
            numbers = new() { 12,3,'#',7,'d',38};

            //Act
            int actual = provider.GetSumOfNumbers(numbers);

            //Assert
            Assert.NotEqual(50, actual);
        }

        [Fact]
        public void ValidNumberList()
        {
            //Arrange
            numbers = new() { 12, 3, 7, 100, 38 };

            //Act
            int actual = provider.GetSumOfNumbers(numbers);

            //Assert
            Assert.Equal(160, actual);
        }
    }
}