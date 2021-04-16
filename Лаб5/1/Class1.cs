using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _lab5
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.Write("Матриця на NxN = ");
            int n = int.Parse(Console.ReadLine());
            int[,] mass = new int[n, n]; //массив размерностью n на n
            Matrix A = new Matrix(n, n);
            Matrix B = new Matrix(n, n);

            Console.WriteLine("Матрица А: ");
            A.Create();
            A.Print();

            Console.WriteLine("Матрица В: ");
            B.Create();
            B.Print();

            //Console.WriteLine("Транспонированная матрица ");
            //B.Transp();
            //Console.WriteLine();

            Console.WriteLine("добавления матриц А и Б: ");
            Console.WriteLine();
            Matrix C = A + B;
            C.Print();

            Console.WriteLine("умножения матриц А и Б:");
            Console.WriteLine();
            C = A * B;
            C.Print();

            Console.WriteLine("вычитание матриц А и Б:");
            C = A - B;
            C.Print();

            Console.WriteLine("определитель матрицы А: ");
            double det = Matrix.GetDeterminant(mass);
            Console.WriteLine("определитель = {0}.", det);
        }

    }
}