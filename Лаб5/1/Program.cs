using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _lab5
{
    class Matrix
    {


        // Скрытые поля
        private int n;
        private int m;

        private int[,] data;


        // Создаем конструкторы матрицы
        public int N
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }

        public void Create()      //метод ввода матрицы
        {
            Random rnd = new Random(); // объект, который будем исппользовать для генерации рандомных целых чисел
            for (int i = 0; i < m; i++) //строки
            {
                for (int j = 0; j < n; j++) //столбцы
                {
                    data[i, j] = rnd.Next(0, 20); // диапазон случайных чисел от -50 до 50
                }
            }
        }

        public void Print()   //метод вивода матриці
        {
            for (int i = 0; i < m; i++) //строки
            {
                for (int j = 0; j < n; j++) //столбцы
                {
                    //mass[i, j] = rnd.Next(-50, 50); // диапазон случайных чисел от -50 до 50
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }

        }
        public void Transp() //Метод транспонирования матрицы
        {
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }

        }

        public void Opr() //Метод нахождения определителя матрицы
        {

        }

        // Задаем аксессоры для работы с полями вне класса Matrix
        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new int[m, n];
        }

        public int this[int i, int j]
        {
            get
            {
                return data[i, j];
            }
            set
            {
                data[i, j] = value;
            }
        }
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.n, B.m);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    C.data[i, j] = A.data[i, j] + B.data[i, j];
                }
            }
            return C;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix D = new Matrix(A.n, B.m);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    D.data[i, j] = A.data[i, j] - B.data[i, j];
                }
            }
            return D;
        }

        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix E = new Matrix(A.n, B.m);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    E.data[i, j] = 0;
                    for (int k = 0; k < A.n; k++)
                    {
                        E.data[i, j] = E.data[i, j] + A.data[k, j] * B.data[i, k];
                    }
                }
            }
            return E;
        }
        static public bool NextPermutation(int[] numList)
        {
            /*
             Knuths
             1. Ищем максимальный индекс j такой, что a[j] < a[j + 1]. Если такого индекса нет, то перестановка последняя.
             2. Найти наибольший индекс l такой, что a[j] < a[l]. Т.к. j + 1 при этом существует, 
             * то l всегда удовлетворяет условию j < l
             3. Меняем местами a[j] и a[l].
             4. Разворачиваем последовательность, начиная a[j + 1] пока не войдёт последний элементa[n].
             */

            //1.
            int largestIndex = -1;
            for (int i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0) return false;
            //2.
            int largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }
            //3.
            int tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;
            //4.
            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }

            return true;
        }

        /// <summary>
        /// Метод вычисления определителя матрицы по основному определению.
        /// </summary>
        static public int GetDeterminant(int[,] m)
        {
            if (m.GetLength(0) != m.GetLength(1))
                throw new ArgumentException("Для поиска определителя матрица должна быть квадратной.");

            int result = 0, prod = 1;
            /// Массив индексов. Выполняя в нём перестановки
            /// будем получать все возможные комбинации для произведения элементов матрицы
            int[] indices = IndicesMatrix(m.GetLength(0));

            int sign = 0;
            /// Для вывода результирующей строки
            StringBuilder sb = new StringBuilder();

            do
            {
                for (int i = 0; i < m.GetLength(0); i++)
                {
                    sb.AppendFormat("{0}m{1}{2}", (i == 0 ? string.Empty : "*"), i, indices[i]);
                    prod *= m[i, indices[i]];
                }

                sign = (int)Math.Pow(-1, Inversions(indices));
                result += sign * prod;

                sb.AppendFormat(" {0} ", sign > 0 ? "+" : "-");

                prod = 1;
            } while (NextPermutation(indices));

            sb.Remove(sb.Length - 3, 3);
            Debug.WriteLine("result = {0}", sb);

            return result;
        }

        /// <summary>
        /// Метод для получения исходного массива индексов
        /// </summary>
        /// <param name="n">Размерность массива индексов</param>
        static private int[] IndicesMatrix(int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++) result[i] = i;
            return result;
        }

        /// <summary>
        /// Метод для определения чётности или нечётности перестановки
        /// </summary>
        /// <remarks>Перестановка называется чётной, если число инверсий в ней чётно,
        /// и нечётной — в противном случае. Инверсию образуют два числа в перестановке,
        /// когда меньшее из них расположено правее большего</remarks>
        static private int Inversions(int[] m)
        {
            int result = 0;
            for (int i = 0; i < m.Length; i++)
                for (int j = i + 1; j < m.Length; j++)
                    if (m[i] > m[j]) result++;
            return result;
        }

        //Деструктор Matrix
        ~Matrix()
        {
            Console.WriteLine("Очистка");
        }

    }
}