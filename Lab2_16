//1.6
using System;
using System.Globalization;

    public class MyClass
    {
        // три целочисленных поля
        private int First, Second, Third;
        
        // конструктор
        public MyClass(int first, int second, int third)
        {
            First = first;
            Second = second;
            Third = third;
        }
        
        // конструктор копирования
        public MyClass(MyClass other)
        {
            First = other.First;
            Second = other.Second;
            Third = other.Third;
        }
        
        // метод вычисления минимальной из последних цифр полей
        public int MinLast()
        {
            int FirstLast = Math.Abs(First) % 10;
            int SecondLast = Math.Abs(Second) % 10;
            int ThirdLast = Math.Abs(Third) % 10;
            return Math.Min(Math.Min(FirstLast, SecondLast), ThirdLast);
        }
        
        // перегрузка оператора ToString
        public override string ToString()
        {
            return $"First: {First}; Second: {Second}; Third: {Third}";
        }
    }

    public class Vector : MyClass
    {
        private int X, Y, Z;

        // конструктор
        public Vector(int First, int Second, int Third, int x, int y, int z)
            : base(First, Second, Third)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //конструктор копирования
        public Vector(Vector other)
            : base(other)
        {
            X = other.X;
            Y = other.Y;
            Z = other.Z;
        }

        //метод вычисления длины вектора
        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        //Перегрузка метода ToString()
        public override string ToString()
        {
            return $"{base.ToString()}, X: {X}; Y: {Y}; Z: {Z}";
        }
    }

class Program
{
    static void Main(string[] args)
    {
        // тест основного класса MyClass
        Console.Write("Введите целое число (x): ");
        string X = Console.ReadLine();

        Console.Write("Введите целое число (y): ");
        string Y = Console.ReadLine();

        Console.Write("Введите целое число (z): ");
        string Z = Console.ReadLine();

        if (int.TryParse(X, out int x) && int.TryParse(Y, out int y) && int.TryParse(Z, out int z))
        {
            Console.WriteLine();
            Console.WriteLine("тестирование основного класса MyClass");
            MyClass new_int = new MyClass(x, y, z);
            Console.WriteLine(new_int.ToString());
            Console.WriteLine("Минимальная последня цифра = " + new_int.MinLast());
            
            MyClass new_int_copy = new MyClass(new_int);
            Console.WriteLine(new_int_copy.ToString());
            Console.WriteLine();
            
            //тестирование дочернего класса Vector
            Console.WriteLine("тестирование дочернего класса Vector");
            Vector vector = new Vector(x, y, z, x, y, z);
            Console.WriteLine(vector.ToString());
            Console.WriteLine("Длина = " + vector.Length());
        }
        else
        {
            Console.WriteLine("Введены неверные данные, введите три целых числа");
        }
    }
}
