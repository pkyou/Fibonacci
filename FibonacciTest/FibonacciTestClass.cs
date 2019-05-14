using FibonacciBusiness;
using Xunit;

namespace FibonacciTest
{
    public class FibonacciTestClass
    {
        [Fact]
        public void ShouldReturn1WhenGetFirstItem()
        {
            Assert.Equal(1,Fibonacci.GetItemByIndex(1));
        }

        [Fact]
        public void ShouldReturn1WhenGetSecondItem()
        {
            Assert.Equal(1,Fibonacci.GetItemByIndex(2));
        }
 
        [Fact]
        public void ShouldReturnSumOfFirstAndSecWhenGetThirdItem()
        {
            Assert.Equal(Fibonacci.GetItemByIndex(1)+Fibonacci.GetItemByIndex(2),Fibonacci.GetItemByIndex(3));
        }
        
        [Fact]
        public void ShouldReturn34WhenGetNinethItem()
        {
            Assert.Equal(34,Fibonacci.GetItemByIndex(9));
        }
        
    }
}