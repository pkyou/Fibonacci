using FibonacciBusiness;
using Xunit;

namespace FibonacciTest
{
    public class FibonacciTestClass
    {

        private Fibonacci _fibonacci = new Fibonacci(); 
        
        [Fact]
        public void ShouldReturn1WhenGetFirstItem()
        {
            Assert.Equal(1,_fibonacci.GetItemByIndex(1));
        }
    }
}