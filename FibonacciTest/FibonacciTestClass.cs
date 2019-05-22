using FibonacciBusiness;
using Xunit;

namespace FibonacciTest
{
    public class FibonacciTestClass
    {
        [Fact]
        public void ShouldReturn1WhenGetFirstItem()
        {
            Assert.Equal(1, Fibonacci.GetItemByIndex(1));
        }

        [Fact]
        public void ShouldReturn1WhenGetSecondItem()
        {
            Assert.Equal(1, Fibonacci.GetItemByIndex(2));
        }

        [Fact]
        public void ShouldReturn1WhenGetThirdItem()
        {
            Assert.Equal(1, Fibonacci.GetItemByIndex(3));
        }

        [Fact]
        public void ShouldReturn3WhenGetFourthItem()
        {
            Assert.Equal(3, Fibonacci.GetItemByIndex(4));
        }
        
        [Fact]
        public void ShouldReturnSumOfFirstAndSecWhenGetThirdItem()
        {
            Assert.Equal(Fibonacci.GetItemByIndex(1) + Fibonacci.GetItemByIndex(2) + Fibonacci.GetItemByIndex(3), Fibonacci.GetItemByIndex(4));
        }

        [Fact]
        public void ShouldReturn355WhenGetTwelveItem()
        {
            Assert.Equal(355, Fibonacci.GetItemByIndex(12));
        }

        [Fact]
        public void ShouldBeEqualWhenBigData()
        {
            Assert.Equal(Fibonacci.GetItemByIndex(1200),Fibonacci.GetItemByIndex(1199)+Fibonacci.GetItemByIndex(1198) + Fibonacci.GetItemByIndex(1197));
        }
    }
}