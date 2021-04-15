using System;

namespace Lab1
{

    class Program
    {

        delegate double Anonim(double x, double y, double w);
        static void Main(string[] args)
        {
            Console.WriteLine("Первое число -->");
            double x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Второе число -->");
            double y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Третье число -->");
            double w = Convert.ToInt32(Console.ReadLine());
            // Инициализация чисел для вввода с консоля

            Anonim del = (x, y, w) => (double)(x + y + w) / 3; //Поиск среднего арифметического чисел
            Console.WriteLine("Среднее арифметическое введенных числел {0:##.###}", del(x, y, w));

            Console.ReadKey();
        }
    }
}
