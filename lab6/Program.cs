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
            // Задание 4: LINQ запросы
            TestLinqQueries();
        }

        static void TestLinqQueries()
        {
            // Исходные данные
            var items = new List<string> { "apple", "banana", "cherry", "date", "apple", "banana", "cherry" };

            // 1. Фильтрация
            var filteredItems = items.Where(item => item.StartsWith("b"));
            Console.WriteLine("Фильтрация: " + string.Join(", ", filteredItems));

            // 2. Анонимные типы
            var anonymousTypes = items.Select(item => new { Name = item, Length = item.Length });
            foreach (var item in anonymousTypes)
            {
                Console.WriteLine($"Имя: {item.Name}, Длина: {item.Length}");
            }

            // 3. Группировка (from)
            var groupedItems = from item in items
                               group item by item into g
                               select new { Name = g.Key, Count = g.Count() };

            Console.WriteLine("Группировка:");
            foreach (var group in groupedItems)
            {
                Console.WriteLine($"Имя: {group.Name}, Количество: {group.Count}");
            }

            // 4. ToArray()
            var arrayItems = items.ToArray();
            Console.WriteLine("ToArray: " + string.Join(", ", arrayItems));

            // 5. ToList()
            var listItems = items.ToList();
            Console.WriteLine("ToList: " + string.Join(", ", listItems));

            // 6. Take()
            var takeItems = items.Take(3);
            Console.WriteLine("Take: " + string.Join(", ", takeItems));

            // 7. Skip()
            var skipItems = items.Skip(2);
            Console.WriteLine("Skip: " + string.Join(", ", skipItems));

            // 8. OrderBy()
            var orderedItems = items.OrderBy(item => item);
            Console.WriteLine("OrderBy: " + string.Join(", ", orderedItems));

            // 9. OrderByDescending()
            var orderedDescItems = items.OrderByDescending(item => item);
            Console.WriteLine("OrderByDescending: " + string.Join(", ", orderedDescItems));

            // 10. Any()
            var anyBanana = items.Any(item => item == "banana");
            Console.WriteLine("Any 'banana': " + anyBanana);

            // 11. First()
            var firstItem = items.First();
            Console.WriteLine("First: " + firstItem);

            // 12. FirstOrDefault()
            var firstOrDefaultItem = items.FirstOrDefault(item => item == "pineapple") ?? "Not found";
            Console.WriteLine("FirstOrDefault: " + firstOrDefaultItem);

            // 13. Distinct()
            var distinctItems = items.Distinct();
            Console.WriteLine("Distinct: " + string.Join(", ", distinctItems));

            // 14. Count()
            var itemCount = items.Count();
            Console.WriteLine("Count: " + itemCount);

            // 15. Sum()
            var lengthsSum = items.Sum(item => item.Length);
            Console.WriteLine("Sum of lengths: " + lengthsSum);
        }
    }
}
