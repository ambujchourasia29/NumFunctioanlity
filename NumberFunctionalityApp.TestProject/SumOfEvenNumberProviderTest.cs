using ConsoleApp;
using ConsoleApp.Contracts;
using NumberFunctionalityApp.Contracts;

namespace NumberFunctionalityApp.TestProject
{
    public class SumOfEvenNumberProviderTest
    {
        ISumOfEvenNumberProvider provider;
        List<int>? numbers;

        public SumOfEvenNumberProviderTest()
        {
            provider = new SumOfEvenNumberProvider();
        }
        [Fact]
        public void EmptyNumberList()
        {
            //Arrange
            numbers = new List<int>();
            
            //Act
            int actual = provider.GetSumOfEvenNumbers(numbers);

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
                provider.GetSumOfEvenNumbers(null);
            });

        }

        [Fact]
        public void WithInvalidCharInNumberList()
        {
            //Arrange
            numbers = new() { 12,3,'#',7,'d',38};

            //Act
            int actual = provider.GetSumOfEvenNumbers(numbers);

            //Assert
            Assert.NotEqual(50, actual);
        }

        [Fact]
        public void ValidNumberList()
        {
            //Arrange
            numbers = new() { 12, 3, 7, 100, 38 };

            //Act
            int actual = provider.GetSumOfEvenNumbers(numbers);

            //Assert
            Assert.Equal(150, actual);
        }
    }
}