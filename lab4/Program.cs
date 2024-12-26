using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IndependentWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1: Подсчет частоты слов
            CountWordFrequency();

            // Задание 2: Динамический массив
            TestDynamicArray();

            // Задание 3: Сортировка массива
            TestArraySorter();
        }

        // Задание 1: Подсчет частоты слов
        static void CountWordFrequency()
        {
            Console.WriteLine("Введите английский текст:");
            string? text = Console.ReadLine()?.ToLower();

            if (string.IsNullOrEmpty(text))
            {
                Console.WriteLine("Текст не может быть пустым.");
                return;
            }

            char[] delimiters = { ' ', '.' };
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            Console.WriteLine("Частота слов:");
            foreach (var pair in wordFrequency)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        // Задание 2: Тестирование DynamicArray<T>
        static void TestDynamicArray()
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();

            for (int i = 0; i < 10; i++)
            {
                dynamicArray.Add(i);
            }

            Console.WriteLine("Элементы динамического массива:");
            for (int i = 0; i < dynamicArray.Length; i++)
            {
                Console.Write(dynamicArray[i] + " ");
            }

            dynamicArray.Remove(5);
            Console.WriteLine("\nПосле удаления элемента 5:");
            for (int i = 0; i < dynamicArray.Length; i++)
            {
                Console.Write(dynamicArray[i] + " ");
            }
        }

        // Задание 3: Сортировка массива с использованием делегата
        static void TestArraySorter()
        {
            int[] array = { 5, 3, 8, 1, 4, 7, 6, 2 };
            Console.WriteLine("Исходный массив: " + string.Join(", ", array));

            ArraySorter<int> sorter = new ArraySorter<int>();
            sorter.SortCompleted += (sender, e) => Console.WriteLine("Сортировка завершена.");

            sorter.Sort(array, (x, y) => x.CompareTo(y));

            Console.WriteLine("Отсортированный массив: " + string.Join(", ", array));
        }
    }

    public class DynamicArray<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _count;

        public int Length => _count;
        public int Capacity => _array.Length;

        public DynamicArray()
        {
            _array = new T[8];
            _count = 0;
        }

        public DynamicArray(int capacity)
        {
            _array = new T[capacity];
            _count = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            _array = collection.ToArray();
            _count = _array.Length;
        }

        public void Add(T item)
        {
            EnsureCapacity(_count + 1);
            _array[_count++] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            var items = collection.ToArray();
            EnsureCapacity(_count + items.Length);
            foreach (var item in items)
            {
                _array[_count++] = item;
            }
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_array, item, 0, _count);
            if (index < 0)
                return false;

            for (int i = index; i < _count - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[--_count] = default!;
            return true;
        }

        public bool Insert(int index, T item)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException();

            EnsureCapacity(_count + 1);

            for (int i = _count; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = item;
            _count++;
            return true;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException();
                _array[index] = value;
            }
        }

        private void EnsureCapacity(int min)
        {
            if (min > _array.Length)
            {
                int newCapacity = _array.Length == 0 ? 4 : _array.Length * 2;
                if (newCapacity < min)
                    newCapacity = min;
                Array.Resize(ref _array, newCapacity);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class ArraySorter<T>
    {
        public event EventHandler? SortCompleted;

        public void Sort(T[] array, Func<T, T, int> compare)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (compare(array[i], array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            OnSortCompleted();
        }

        protected virtual void OnSortCompleted()
        {
            SortCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
