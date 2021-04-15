using System;

namespace Lab1
{
    public delegate int Number();
    public delegate int MediumCalc(Number[] arrayX);
    class Program
    {
        public static int Random()
        {
            Random rand = new Random();
            return rand.Next(1, 10);
        }
        static void Main(string[] args)
        {
            Number[] numArr = new Number[5];//Выбираем 5 рандомных чисел в диапазоне от [1;10]
            for (int i = 0; i < numArr.Length; i++)
            {
                numArr[i] = Random;
                Console.Write(" " + numArr[i].Invoke() + " ");
                // Метод Invoke принимает делегат
                //и выполняет его в том потоке, в котором был создан элемент управления
            }
            Console.WriteLine();

            MediumCalc mediumCalc = delegate (Number[] arrayX)
            {
                int sum = 0;//иницыализация суммы
                for (int i = 0; i < arrayX.Length; i++)
                {
                    sum += arrayX[i]();
                }
                // Перебираем все элементы
                // и складываем их в сумму
                return ((sum) / (arrayX.Length));// Среднее арифметическое
            };

            Console.WriteLine(mediumCalc(numArr));

            Console.ReadKey();
        }
    }
}

