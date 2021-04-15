using System;

using System;

namespace Lab2
{
    class MyList<T>
    {
        private T[] myList = null;

        public T this[int index]
        {
            get { return myList[index]; }
            set { myList[index] = value; }
        }

        public MyList()
        {
            this.myList = new T[1];
        }

        public MyList(int count)
        {
            this.myList = new T[count];
        }

        public void Add(T item)
        {
            T[] extendedList = new T[myList.Length + 1];
            extendedList[extendedList.Length - 1] = item;
            myList = extendedList;
        }

        public int Capacity
        {
            get { return myList.Length; }

        }

        //  Возвращает число элементов, которые фактически содержатся в коллекции MyList<T>.

        public int Count
        {
            get
            {
                int count = 0;
                for (int i = 0; i < myList.Length; i++)
                {
                    if (myList[i].ToString() != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> mylist = new MyList<int>(5);
            mylist[0] = 1;
            Console.WriteLine("Емкость списка: {0} элемент(-ов)", mylist.Capacity);
            Console.WriteLine("Список фактически содержит: {0} элемент(-ов)", mylist.Count);
            mylist.Add(15);
            Console.WriteLine("Емкость списка: {0} элемент(-ов)", mylist.Capacity);

            Console.ReadKey();
        }
    }
}
