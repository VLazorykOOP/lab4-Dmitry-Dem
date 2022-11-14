using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    /*----Task-1------------*/
    class Money
    {
        public double First { get; set; }
        public double Second { get; set; }
        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return First;
                }
                else if (index == 1)
                {
                    return Second;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (index == 0)
                {
                    First = value;
                }
                else if (index == 1)
                {
                    Second = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public Money()
        {

        }
        public Money(double first, double second)
        {
            First = first;
            Second = second;
        }

        public static explicit operator Money(string fields) => new Money { First = Convert.ToDouble(fields.Split(" ")[0]), Second = Convert.ToDouble(fields.Split(" ")[1]) };

        public static implicit operator string(Money money) => $"{money[0]} {money[1]}";
        public static Money operator ++(Money money) => new Money { First = money[0]++, Second = money[1]++ };
        public static Money operator --(Money money) => new Money { First = money[0]--, Second = money[1]-- };
        public static bool operator !(Money money) => money[1] != 0;
        public static Money operator +(Money money1, Money money2) => new Money(money1[0] + money2[0], money1[1] + money2[1]);
        public static Money operator -(Money money1, Money money2) => new Money(money1[0] - money2[0], money1[1] - money2[1]);
    }
    /*----------------------*/


    /*----Task-2------------*/

    /*----------------------*/


    /*----Task-3------------*/

    /*----------------------*/
}
