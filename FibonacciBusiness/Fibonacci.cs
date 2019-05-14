using System.Numerics;

namespace FibonacciBusiness
{
    public class Fibonacci
    {
        public static BigInteger GetItemByIndex(int index)
        {
            if (index <= 0)
            {
                return 0;
            }

            if (index == 1 || index == 2)
            {
                return 1;
            }

            BigInteger preItem = 1;
            BigInteger prePreItem = 1;
            BigInteger temp = 0;

            for (int i = 2; i < index; i++)
            {
                temp = prePreItem + preItem;
                prePreItem = preItem;
                preItem = temp;
            }

            return temp;
        }
    }
}