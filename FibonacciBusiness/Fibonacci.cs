using System;
using System.Numerics;

namespace FibonacciBusiness
{
    public class Fibonacci
    {
        public static BigInteger GetItemByIndex(int i)
        {
            if (i <= 0)
            {
                return 0;
            }
            
            if (i == 1 || i == 2)
            {
                return 1;
            }

            BigInteger preItem = 1;
            BigInteger prePreItem = 1;
            BigInteger temp = 0;
            
            for (int j = 2; j < i; j++)
            {
                temp = prePreItem + preItem;
                prePreItem = preItem;
                preItem = temp;
            }
            
            return temp;
        }
    }
}