using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<char> mylist = new MyList<char>();
            for (int i = 15; i < 20; i++)
            {
                mylist.Add((char)i);
            }
            Console.WriteLine(new string('=', 15));
            Console.WriteLine(mylist.Count);
            Console.WriteLine(new string('=', 15));
            //   IEnumerable<char> enumerable = mylist as IEnumerable<char>;
            for (int i = 0; i < mylist.Count; i++)
            {
                Console.WriteLine(mylist.GetArray()[i]);

            }
        }
    }
    public static class TClass
    {
        public static T[] GetArray<T>(this IEnumerable<T> list)
        {
            int i = 0; T[] array = new T[i];
            foreach (T item in list)
            {
                T[] NewArray = new T[array.Length + 1];
                array.CopyTo(NewArray, 0);
                NewArray[array.Length] = item;
                array = NewArray;

            }
            return array;
        }
    }
    class MyList<T> : IEnumerable<T>
    {
        T[] array = new T[0];
        public T this[int index]
        {
            get
            {
                return array[index];
            }
        }
        public void Add(T item)
        {
            T[] NewArray = new T[array.Length + 1];
            array.CopyTo(NewArray, 0);
            NewArray[array.Length] = item;
            array = NewArray;
        }
        public int Count
        {
            get { return array.Length; }
        }
        int position = -1;
        public object Current
        {
            get { return array[position]; }
        }

        public bool MoveNext()
        {
            if (position < array.Length - 1)
            {
                position++;
                return true;
            }
            else { Reset(); return false; }
        }
        public void Reset()
        {
            position = -1;
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in array)
                yield return item;
        }




        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }


    }
}
