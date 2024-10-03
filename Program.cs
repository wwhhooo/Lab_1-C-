using System;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;


namespace Lab_1
{
    internal class Program
    {
        private Random random;

        public Program(Random random)
        {
            this.random = random;
        }

        public static double Fraction(double x)
        {
            return x - (int)x;
        }

        public static int CharToNum(char x)
        {
                return x - '0';
        }

        public static bool Is2Digits(int x) 
        {
            return x >= 10 && x <= 99;
        }

        public static bool IsInRange(int a, int b, int num)
        {
            return (a <= num && num <= b) || (b <= num && num <= a);
        }

        public static bool IsEqual(int a, int b, int c)
        {
            return a == b && b == c && c == a;
        }

        public static int Abs(int x)
        {
            if (x >= 0)
            {
                return x;
            }
            else
            {
                return -x;
            }
        }

        public static bool Is35(int x)
        {
            bool xxx = true;

            if ((x % 3 == 0) && (x % 5 == 0))
            {
                xxx = false;
            }
            if (((x % 3 == 0) || (x % 5 == 0)) && (xxx == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int Max3(int x, int y, int z)
        {
            int max = x;

            if (y > max) max = y;
            if (z > max) max = z;
            return max;
        }

        public static int Sum2(int x, int y)
        {
            int summ = x + y;

            if (10 <= summ && summ <= 19)
            {
                return 20;
            }

            else
            {
                return summ;
            }
        }

        public static String Day(int x)
        {
            switch (x)
            {
                case 1:
                    return "Понедельник";
                case 2:
                    return "Вторник";
                case 3:
                    return "среда";
                case 4:
                    return "четверг";
                case 5:
                    return "пятница";
                case 6:
                    return "суббота";
                case 7:
                    return "воскресенье";
                default:
                    return "это не день недели";
            }
        }

        public static String ListNums(int x)
        {
            String result = "";
            for (int i = 0; i <= x; i++)
            {
                result = result + i + " ";
            }
            return result;
        }

        public static String Chet(int x)
        {
            if (x < 0)
            {
                return "Число должно быть неотрицательным";
            }
            
            String result = "";
            for (int i = 0; i <= x; i+=2)
            {
                result += i + " ";
            }
            return result;
        }

        public static int NumLen(long x)
        {
            if (x < 0)
            {
                x = -x;
            }

            int count = 0;

            while (x != 0)
            {
                x /= 10;
                count++;
            }

            return count == 0 ? 1 : count;
        }

        public static void Square(int x)
        {
            if (x <= 0)
            {
                Console.WriteLine("Число должно быть положительным");
                return;
            }

            for (int i = 0; i < x; i++)
            {
                for(int j = 1; j < x; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("*");
            }
        }

        public static void RightTriangle(int x)
        {
            if (x <= 0)
            {
                Console.WriteLine("Число должно быть положительным");
                return;
            }

            for (int i = 1; i <= x; i++)
            {
                for (int j = 0; j < x - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static int FindFirst(int[] arr, int x)
        {
            Console.Write("Массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x) return i;
            }
            return -1;
        }

        public static int MaxAbs(int[] arr)
        {
            Console.Write("Массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            int maxx = arr[0];
            int max_id = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(Abs(arr[i]) > maxx)
                {
                    maxx = Abs(arr[i]);
                    max_id = arr[i];
                }
            }
            return max_id;
        }

        public static int[] Add(int[] arr, int[] ins, int pos)
        {   
            if (pos <= 0)
            {
                Console.WriteLine("Позиция должнать быть положительным числом");
            }

            Console.Write("1-ый массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            Console.Write("2-ой массив: ");
            for (int i = 0; i < ins.Length; i++)
            {
                Console.Write(ins[i] + " ");
            }
            Console.WriteLine();

            int[] result = new int[arr.Length + ins.Length];

            for (int i = 0; i < pos; i++)
            {
                result[i] = arr[i];
            }

            for (int i = 0; i < ins.Length; i++)
            {
                result[pos + i] = ins[i];
            }

            for (int i = pos; i < arr.Length; i++)
            {
                result[i + ins.Length] = arr[i];
            }

            return result;
        }

        public static int[] ReverseBack(int[] arr)
        {
            Console.Write("Массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = arr[arr.Length - 1 - i];
            }

            return result;
        }

        public static int[] FindAll(int[] arr, int x)
        {
            Console.Write("Массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();

            int counter = 0;
            int[] temp = new int[arr.Length];

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    temp[counter++] = i;
                }
            }
            return temp;
        }


        static void Main(string[] args)
        {
            Random random = new Random();
            Program program = new Program(random);

            Console.Write("Введите номер нужного задания в формате NM, где N - номер блока с заданиями, a M - номер задания в блоке(только нечетные задания): ");
            string num = Console.ReadLine();
            int task_num;

            if (int.TryParse(num, out task_num))
            {
                switch (task_num)
                {
                    case 11:
                        program.Task11();
                        break;

                    case 13:
                        program.Task13();
                        break;

                    case 15:
                        program.Task15();
                        break;

                    case 17:
                        program.Task17();
                        break;

                    case 19:
                        program.Task19();
                        break;

                    case 21:
                        program.Task21();
                        break;

                    case 23:
                        program.Task23();
                        break;

                    case 25:
                        program.Task25();
                        break;

                    case 27:
                        program.Task27();
                        break;

                    case 29:
                        program.Task29();
                        break;

                    case 31:
                        program.Task31();
                        break;

                    case 33:
                        program.Task33();
                        break;

                    case 35:
                        program.Task35();
                        break;

                    case 37:
                        program.Task37();
                        break;

                    case 39:
                        program.Task39();
                        break;

                    case 41:
                        program.Task41();
                        break;

                    case 43:
                        program.Task43();
                        break;

                    case 45:
                        program.Task45();
                        break;

                    case 47:
                        program.Task47();
                        break;

                    case 49:
                        program.Task49();
                        break;

                    default:
                        Console.WriteLine("Такого задания не существует");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Данные введены некорректно, проверьте введенные данные");
            }

        }

        public void Task11() // 1*1 (Дробная часть.)
        {
            Console.Write("Введите вещественное число: ");
            string number = Console.ReadLine();
            if (double.TryParse(number, NumberStyles.Float, CultureInfo.InvariantCulture, out double x))
            {
                double result = Fraction(x);
                Console.WriteLine("Дробная часть от " + x + " = " + result);
            }
            else
            {
                Console.WriteLine("Введите вещественное число (через точку)");
            }

        }

        public void Task13() // 1*3 (Букву в число.)
        {
            Console.Write("Введите символ: ");
            string input = Console.ReadLine();

            if (char.TryParse(input, out char x) && ('0' <= x && x <= '9'))
            {
                int result = CharToNum(x);
                Console.WriteLine("Символ '" + x + "' = " + result);
            }
            else
            {
                Console.WriteLine("Введите единственный символ");
            }
        }

        public void Task15() // 1*5 (Двузначное.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                bool result = Is2Digits(x);
                Console.WriteLine("Число " + x + " - двузначное: " + result);
            }
            else
            {
                Console.WriteLine("Введите число");
            }
        }

        public void Task17() // 1*7 (Диапазон.)
        {
            Console.Write("Введите левую границу диапазона (a): ");
            string A = Console.ReadLine();

            Console.Write("Введите правую границу диапазона (b): ");
            string B = Console.ReadLine();

            Console.Write("Введите число: ");
            string Num = Console.ReadLine();

            if (int.TryParse(A, out int a) && int.TryParse(B, out int b) && int.TryParse(Num, out int num))
            {
                bool result = IsInRange(a, b, num);
                Console.WriteLine("Число " + num + " входит в границы между " + a + " и " + b + ": " + result);
            }
            else
            {
                Console.WriteLine("Некорректный ввод, введите три числа");
            }
        }

        public void Task19() // 1*9 (Равенство.)
        {
            Console.Write("Введите целое число (a): ");
            string A = Console.ReadLine();

            Console.Write("Введите целое число (b): ");
            string B = Console.ReadLine();

            Console.Write("Введите целое число (c): ");
            string C = Console.ReadLine();

            if (int.TryParse(A, out int a) && int.TryParse(B, out int b) && int.TryParse(C, out int c))
            {
                bool result = IsEqual(a, b, c);
                Console.WriteLine("Все числа равны: " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите три целых числа");
            }
        }

        public void Task21() // 2*1 (Модуль числа.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                int result = Abs(x);
                Console.WriteLine("Модуль числа " + x + " = " + result);
            }
            else
            {
                Console.WriteLine("Данные введены некорректно, проверьте введенные данные");
            }
        }

        public void Task23() // 2*3 (Тридцать пять.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                bool result = Is35(x);
                Console.WriteLine("Число " + x + " = " + result);
            }
            else
            {
                Console.WriteLine("Данные введены некорректно, проверьте введенные данные");
            }
        }

        public void Task25() // 2*5 (Тройной максимум.)
        {
            Console.Write("Введите целое число (x): ");
            string X = Console.ReadLine();

            Console.Write("Введите целое число (y): ");
            string Y = Console.ReadLine();

            Console.Write("Введите целое число (z): ");
            string Z = Console.ReadLine();

            if (int.TryParse(X, out int x) && int.TryParse(Y, out int y) && int.TryParse(Z, out int z))
            {
                int result = Max3(x, y, z);
                Console.WriteLine("Самое большое число = " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите три целых числа");
            }
        }

        public void Task27() // 2*7 (Двойная сумма.)
        {
            Console.Write("Введите целое число (x): ");
            string X = Console.ReadLine();

            Console.Write("Введите целое число (y): ");
            string Y = Console.ReadLine();

            if (int.TryParse(X, out int x) && int.TryParse(Y, out int y))
            {
                int result = Sum2(x, y);
                Console.WriteLine("Сумма " + x + " + " + y + " = " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите два целых числа");
            }
        }

        public void Task29() // 2*9 (День недели.)
        {
            Console.Write("Введите число, обозначающее день недели (1-7): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                string result = Day(x);
                Console.WriteLine("Результат: " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите число от 1 до 7");
            }
        }

        public void Task31() // 3*1 (Числа подряд.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                string result = ListNums(x);
                Console.WriteLine("Результат: " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите целое число");
            }
        }

        public void Task33() // 3*3 (Четные числа.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                string result = Chet(x);
                Console.WriteLine("Результат: " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите целое число");
            }
        }

        public void Task35() // 3*5 (Длина числа.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (long.TryParse(input, out long x))
            {
                int result = NumLen(x);
                Console.WriteLine("В числе " + x + " : " + result + " знаков");
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите число");
            }
        }

        public void Task37() // 3*7 (Квадрат.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                Square(x);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите число");
            }
        }

        public void Task39() // 3*9 (Правый треугольник.)
        {
            Console.Write("Введите число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int x))
            {
                RightTriangle(x);
            }
            else
            {
                Console.WriteLine("Введены неверные данные, введите число");
            }
        }

        public void Task41() // 4*1 (Поиск первого значения.)
        {
            Console.Write("Введите целое число: ");
            string number = Console.ReadLine();

            Console.Write("Введите размер массива( > 0): ");
            string mass = Console.ReadLine();

            if (int.TryParse(number, out int x) && int.TryParse(mass, out int size) && size > 0)
            {
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = random.Next(1, 10);
                }
                int result = FindFirst(arr, x);
                Console.WriteLine("Индекс первого вхождения: " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные");
            }
        }

        public void Task43() // 4*3 (Поиск максимального.)
        {
            Console.Write("Введите размер массива( > 0): ");
            string mass = Console.ReadLine();

            if (int.TryParse(mass, out int size) && size > 0)
            {
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = random.Next(-10, 10);
                }

                int result = MaxAbs(arr);
                Console.WriteLine("Наибольший по модулю элемент массива = " + result);
            }
            else
            {
                Console.WriteLine("Введены неверные данные");
            }
        }

        public void Task45() // 4*5 (Добавление массива в массив.)
        {
            Console.Write("Введите размер 1-ого массива ( > 0): ");
            string mass1 = Console.ReadLine();
            Console.Write("Введите размер 2-ого массива ( > 0): ");
            string mass2 = Console.ReadLine();
            Console.Write("Введите номер позиции: ");
            string position = Console.ReadLine();
            if (int.TryParse(mass1, out int size) && int.TryParse(mass2, out int size2) && int.TryParse(position, out int pos) && size > 0 && size2 > 0)
            {
                int[] arr = new int[size];
                int[] ins = new int[size2];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = random.Next(1, 10);
                }
                for (int i = 0; i < size2; i++)
                {
                    ins[i] = random.Next(1, 10);
                }
                int[] result = Add(arr, ins, pos);
                Console.Write("Результат: ");
                for (int i = 0; i < arr.Length + ins.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("Введены неверные данные");
            }
        }

        public void Task47() // 4*7 (Возвратный реверс.)
        {
            Console.Write("Введите размер массива ( > 0): ");
            string mass = Console.ReadLine();

            if (int.TryParse(mass, out int size) && size > 0)
            {
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = random.Next(-10, 10);
                }

                int[] result = ReverseBack(arr);
                Console.Write("Результат: ");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("Введены неверные данные");
            }
        }

        public void Task49() // 4*9 (Все вхождения.)
        {
            Console.Write("Введите целое число: ");
            string number = Console.ReadLine();

            Console.Write("Введите размер массива ( > 0): ");
            string mass = Console.ReadLine();

            if (int.TryParse(number, out int x) && int.TryParse(mass, out int size) && size > 0)
            {
                int[] arr = new int[size];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = random.Next(1, 10);
                }
                int[] result = FindAll(arr, x);
                Console.Write("Результат: ");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write(result[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("Введены неверные данные");
            }
        }
    }
        
}
