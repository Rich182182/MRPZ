using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class InputValidator
    {
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    int value = int.Parse(Console.ReadLine());
                    if (value < 0) throw new Exception("Значення не може бути від'ємним.");
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: Введено некоректне число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }

        public static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                try
                {
                    double value = double.Parse(Console.ReadLine());
                    if (value <= 0) throw new Exception("Площа має бути більшою за нуль.");
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: Введено некоректне число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }

        public static BuildingType ReadBuildingType()
        {
            while (true)
            {
                Console.WriteLine("\nДоступні типи будівель:");
                foreach (var type in Enum.GetValues(typeof(BuildingType)))
                {
                    Console.WriteLine($"{(int)type} - {type}");
                }

                Console.Write("Оберіть тип (введіть число): ");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (Enum.IsDefined(typeof(BuildingType), choice))
                    {
                        return (BuildingType)choice;
                    }
                    throw new Exception("Такого варіанту немає в списку.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Помилка: Введено некоректне число.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }
            }
        }
    }
}
