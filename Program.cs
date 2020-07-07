using System;

namespace ks_Target_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction<string> fraction1 = new Fraction<string>("3", "5");
            Fraction<string> fraction2 = new Fraction<string>("5", "6");
            var frSum = fraction1 + fraction2;
            var frSub = fraction1 - fraction2;
            var frMult = fraction1 * fraction2;


            fraction1.print();
            frSum.print();
            frSub.print();
            frMult.print();
        }
    }

    class Fraction<T>
    {
        private long x;
        private long y;
        public Fraction(T x, T y)
        {
            try
            {
                if (typeof(T).ToString() == "System.Boolean" | typeof(T).ToString() == "System.Char" | typeof(T).ToString() == "System.Object")
                {
                    throw new Exception("Невозможный тип");
                }
                else if(typeof(T).ToString() == "System.String")
                {
                    //Проверка строки на пригодность
                    var checkx = Convert.ToInt64(x);
                    var checky = Convert.ToInt64(y);
                    if(checky != 0)
                    {
                        this.x = checkx;
                        this.y = checky;
                    }
                    else
                    {
                        throw new Exception("Деление на ноль");
                    }

                    
                } else if(typeof(T).ToString() == "System.Single" | typeof(T).ToString() == "System.Double" | typeof(T).ToString() == "System.Decimal")
                {
                    this.x = (long)Math.Floor(Convert.ToDouble(x));
                    this.y = (long)Math.Floor(Convert.ToDouble(y));

                } else
                {
                    this.x = Convert.ToInt64(x);
                    this.y = Convert.ToInt64(y);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }


        }

        public void print()
        {
            Console.WriteLine((x/nod(x,y)) + "/" + (y / nod(x, y)));
        }

        private long nod(long a, long b)
        {
            while (b != 0)
                b = a % (a = b);
            return a;
        }

        public static Fraction<long> operator +(Fraction<T> f1, Fraction<T> f2)
        {
            return new Fraction<long>(f1.x * f2.y + f1.y * f2.x, f1.y * f2.y);
        }

        public static Fraction<long> operator -(Fraction<T> f1, Fraction<T> f2)
        {
            return new Fraction<long>(f1.x * f2.y - f1.y * f2.x, f1.y * f2.y);
        }

        public static Fraction<long> operator *(Fraction<T> f1, Fraction<T> f2)
        {
            return new Fraction<long>(f1.x * f2.x, f1.y * f2.y);
        }

    }
}
