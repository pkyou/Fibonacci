using System;

namespace FibonacciBusiness
{
    public class Fibonacci
    {
        public static decimal GetItemByIndex(int i)
        {
            if (i>=140)
            {
                return 0;
            }
            
            if (i <= 0)
            {
                return 0;
            }
            
            if (i == 1 || i == 2)
            {
                return 1;
            }

            decimal preItem = 1;
            decimal prePreItem = 1;
            decimal temp = 0;
            
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