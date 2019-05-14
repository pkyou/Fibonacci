using System;
using FibonacciBusiness;

namespace FibonacciConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello world");
            Console.WriteLine(Fibonacci.GetItemByIndex(117));
            Console.WriteLine(Fibonacci.GetItemByIndex(118));
            Console.WriteLine(Fibonacci.GetItemByIndex(119));
            Console.WriteLine(Fibonacci.GetItemByIndex(120));
            Console.WriteLine(Fibonacci.GetItemByIndex(121));
            Console.WriteLine(Fibonacci.GetItemByIndex(122));
            Console.WriteLine(Fibonacci.GetItemByIndex(130));
            Console.WriteLine(Fibonacci.GetItemByIndex(131));
            Console.WriteLine(Fibonacci.GetItemByIndex(140));
            Console.WriteLine(Fibonacci.GetItemByIndex(180));
        }
    }
}