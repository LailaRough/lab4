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
            // Демонстрация классов Round, User и Employee
            TestRound();
            TestUserAndEmployee();
        }

        static void TestRound()
        {
            Round round = new Round(0, 0, 5);
            Console.WriteLine($"Координаты центра: ({round.X}, {round.Y}), Радиус: {round.Radius}");
            Console.WriteLine($"Длина окружности: {round.Circumference:F2}");
            Console.WriteLine($"Площадь круга: {round.Area:F2}");
        }

        static void TestUserAndEmployee()
        {
            Console.WriteLine("Введите имя, фамилию, отчество и дату рождения (в формате ГГГГ-ММ-ДД):");
            string name = Console.ReadLine();
            string surname = Console.ReadLine();
            string patronymic = Console.ReadLine();
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            User user = new User(name, surname, patronymic, birthDate);
            Console.WriteLine(user);

            Employee employee = new Employee(name, surname, patronymic, birthDate, "Developer", 5);
            Console.WriteLine(employee);
        }
    }

    // Задание 1a: Класс Round
    public class Round
    {
        public double X { get; }
        public double Y { get; }
        public double Radius { get; }

        public Round(double x, double y, double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус должен быть положительным.");

            X = x;
            Y = y;
            Radius = radius;
        }

        public double Circumference => 2 * Math.PI * Radius;

        public double Area => Math.PI * Math.Pow(Radius, 2);
    }

    // Задание 1b: Класс User
    public class User
    {
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public DateTime BirthDate { get; }

        public int Age => DateTime.Now.Year - BirthDate.Year;

        public User(string name, string surname, string patronymic, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Фамилия: {Surname}, Отчество: {Patronymic}, Дата рождения: {BirthDate:yyyy-MM-dd}, Возраст: {Age}";
        }
    }

    // Задание 1c: Класс Employee
    public class Employee : User
    {
        public string Position { get; }
        public int WorkExperience { get; }

        public Employee(string name, string surname, string patronymic, DateTime birthDate, string position, int workExperience)
            : base(name, surname, patronymic, birthDate)
        {
            Position = position;
            WorkExperience = workExperience;
        }

        public override string ToString()
        {
            return base.ToString() + $", Должность: {Position}, Стаж работы: {WorkExperience} лет";
        }
    }

    // Задание 2: Абстрактный класс, интерфейсы и виртуальные методы
    public abstract class Shape
    {
        public abstract double Area { get; }
        public abstract double Perimeter { get; }

        public virtual void Display()
        {
            Console.WriteLine($"Площадь: {Area:F2}, Периметр: {Perimeter:F2}");
        }
    }

    public interface IColorable
    {
        string Color { get; set; }
        void ChangeColor(string color);
    }

    public class Rectangle : Shape, IColorable
    {
        public double Width { get; }
        public double Height { get; }

        public string Color { get; set; }

        public Rectangle(double width, double height, string color)
        {
            Width = width;
            Height = height;
            Color = color;
        }

        public override double Area => Width * Height;

        public override double Perimeter => 2 * (Width + Height);

        public void ChangeColor(string color)
        {
            Color = color;
            Console.WriteLine($"Цвет изменён на {color}");
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Цвет: {Color}");
        }
    }
}
