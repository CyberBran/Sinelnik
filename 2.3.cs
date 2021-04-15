using System;


namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = MyClass<bool>.FactoryMethod();
            var y = MyClass<decimal>.FactoryMethod();

            Console.WriteLine(x.GetType().Name);
            Console.WriteLine(y.GetType().Name);
        }

    }

    class MyClass<T>
        where T : new()
    {
        public static T FactoryMethod()
        {
            return new T();
        }
    }
}
