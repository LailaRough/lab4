using System;
using System.Linq;

namespace IndependentWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1: Индекс массы тела
            CalculateBMI();

            // Задание 2: Работа с массивом
            ArrayOperations();

            // Задание 3: Средняя длина слов
            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();
            Console.WriteLine("Средняя длина слов: " + CalculateAverageWordLength(input));

            // Задание 4: Работа со struct и параметрами ref/out
            DemonstrateStructUsage();
        }

        // Задание 1: Расчет индекса массы тела
        static void CalculateBMI()
        {
            Console.WriteLine("Введите массу тела (кг):");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост (м):");
            double height = double.Parse(Console.ReadLine());

            double bmi = weight / (height * height);
            Console.WriteLine($"Ваш индекс массы тела: {bmi:F2}");
        }

        // Задание 2: Работа с массивом без использования встроенных методов
        static void ArrayOperations()
        {
            const int arraySize = 10;
            Random random = new Random();
            int[] array = new int[arraySize];

            // Заполнение массива случайными числами
            for (int i = 0; i < arraySize; i++)
            {
                array[i] = random.Next(1, 101);
            }

            Console.WriteLine("Исходный массив: " + string.Join(", ", array));

            // Поиск максимального и минимального значения
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max) max = array[i];
                if (array[i] < min) min = array[i];
            }

            Console.WriteLine($"Максимальное значение: {max}");
            Console.WriteLine($"Минимальное значение: {min}");

            // Сортировка массива
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
        }

        // Задание 3: Расчет средней длины слов
        static double CalculateAverageWordLength(string input)
        {
            char[] delimiters = new char[] { ' ', '\t', '\n', ',', '.', ';', ':', '!', '?' };
            string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            int totalLength = 0;
            foreach (var word in words)
            {
                totalLength += word.Length;
            }

            return words.Length > 0 ? (double)totalLength / words.Length : 0;
        }

        // Задание 4: Демонстрация работы с struct, ref, out
        struct CustomStruct
        {
            public int IntValue;
            public string StringValue;
        }

        static void DemonstrateStructUsage()
        {
            CustomStruct myStruct;
            myStruct.IntValue = 10;
            myStruct.StringValue = "Hello";

            Console.WriteLine($"До изменения: IntValue={myStruct.IntValue}, StringValue={myStruct.StringValue}");

            ModifyStruct(ref myStruct);

            Console.WriteLine($"После изменения: IntValue={myStruct.IntValue}, StringValue={myStruct.StringValue}");

            // Работа с out
            int result;
            CalculateSquare(5, out result);
            Console.WriteLine($"Квадрат числа 5: {result}");
        }

        static void ModifyStruct(ref CustomStruct myStruct)
        {
            myStruct.IntValue = 42;
            myStruct.StringValue = "World";
        }

        static void CalculateSquare(int number, out int square)
        {
            square = number * number;
        }
    }
}
