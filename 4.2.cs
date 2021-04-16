using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace события
{
    public delegate void MyDelegate(long i);
    public delegate void MyDelegate_1(long i);
    class MyClass
    {
        public event MyDelegate MyEvent_1 = null;
        // public event MyDelegate_1 MyEvent_2 = null;
        public void InvokeEvent_1(long i)
        {
            MyEvent_1.Invoke(i);

        }
        public void InvokkeEvent_2(long i)
        {
            MyEvent_1.Invoke(i);
        }
    }
    class Program
    {
        public static void OnFullScreen(long i)
        {
            Console.WriteLine("\nПродолжаем работу?(для окончания введите 0, для продолжения 1 )");

            if (int.Parse(Console.ReadLine()) == 0)
                System.Environment.Exit(0);
            else
                Console.Clear();
        }
        public static void OnPrimeNumber(long i)
        {
            Console.Write("{0,15}", i);
        }
        public static bool prsrt(long i)
        {
            for (int k = 2; k <= i / 2; k++)
                if (i % k == 0)
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            long a = 1, b = 1, c;
            int count = 2;
            MyClass instance_1 = new MyClass();
            MyClass instance_2 = new MyClass();
            instance_1.MyEvent_1 += OnFullScreen;
            instance_2.MyEvent_1 += OnPrimeNumber;

            for (int i = 1; ; i++)
            {
                if (i < 3)
                    instance_2.InvokeEvent_1(a);
                else
                {
                    c = a + b;
                    a = b;
                    b = c;
                    if (prsrt(c))
                    {
                        instance_2.InvokeEvent_1(c);
                        count++;
                    }
                    if (count == 5)//количество выводимых чисел
                    {
                        count = 0;
                        instance_1.InvokeEvent_1(count);
                    }
                }
            }
        }
    }
}

