
using System;

namespace Lab1
{
    public delegate int MyDelegat(int a, int b);

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите действие--> +,-,*,/");
            string a = Console.ReadLine();
            Console.WriteLine("Первое число -->");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Второе число -->");
            int y = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case "+":
                    MyDelegat myDelegat = (c, b) => c + b; // Выполнение сумирования чисел
                    double Add = myDelegat(x, y);
                    Console.WriteLine("Ответ:{0}", Add);
                    break;
                case "-":
                    MyDelegat myDelegat1 = (c, b) => c - b; // Выполнение вычитания чисел
                    double Sub = myDelegat1(x, y);
                    Console.WriteLine("Ответ:{0}", Sub);
                    break;
                case "*":
                    MyDelegat myDelegat2 = (c, b) => c * b; // Выполнение умножения чисел
                    double Muv = myDelegat2(x, y);
                    Console.WriteLine("Ответ:{0}", Muv);
                    break;
                case "/":
                    MyDelegat myDelegat3 = (c, b) => b != 0 ? c / b : 0; // Выполнение деления чисел, проверка 0
                    // b=0, то вернет 0, :?-тернарный оператор.
                    double Div = myDelegat3(x, y);
                    Console.WriteLine("Ответ:{0}", Div);
                    break;
            }

            Console.ReadKey();

        }
    }
}
