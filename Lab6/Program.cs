using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Console.WriteLine("Вербицький Є. В.");

        Console.Write("Введіть кількість точок у множинах: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count <= 0)
        {
            count = 20;
        }

        HashSet<Point> set1 = new HashSet<Point>();
        HashSet<Point> set2 = new HashSet<Point>();
        Random rand = new Random();

        while (set1.Count < count)
        {
            set1.Add(new Point(rand.Next(0, 10), rand.Next(0, 10)));
        }

        while (set2.Count < count)
        {
            set2.Add(new Point(rand.Next(0, 10), rand.Next(0, 10)));
        }

        Console.WriteLine("\nМножина 1:");
        PrintSet(set1);

        Console.WriteLine("\nМножина 2:");
        PrintSet(set2);

        HashSet<Point> intersection = new HashSet<Point>(set1);
        intersection.IntersectWith(set2);

        Console.WriteLine("\nПеретин множин (спільні точки):");
        PrintSet(intersection);

        HashSet<Point> difference = new HashSet<Point>(set1);
        difference.ExceptWith(set2);
        Console.WriteLine("\nРізниця (Множина 1 - Множина 2):");
        PrintSet(difference);
    }

    static void PrintSet(HashSet<Point> set)
    {
        if (set.Count == 0)
        {
            Console.WriteLine("Порожньо");
            return;
        }
        Console.WriteLine(string.Join(" ", set));
    }
}