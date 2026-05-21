using System;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вербицький Є. В.");

            Apartment[] apartments = new Apartment[10];
            int count = 0;

            apartments[count++] = new Apartment { Number = 12, Area = 45.5, Floor = 3, Rooms = 1, Type = BuildingType.Brick, Lifespan = 50 };
            apartments[count++] = new Apartment { Number = 48, Area = 72.0, Floor = 5, Rooms = 3, Type = BuildingType.Panel, Lifespan = 30 };
            apartments[count++] = new Apartment { Number = 105, Area = 60.0, Floor = 9, Rooms = 2, Type = BuildingType.Monolithic, Lifespan = 15 };

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n--- МЕНЮ ---");
                Console.WriteLine("1. Показати всі квартири");
                Console.WriteLine("2. Додати нову квартиру");
                Console.WriteLine("3. Пошук за кількістю кімнат");
                Console.WriteLine("4. Пошук за площею та поверхом");
                Console.WriteLine("5. Вийти");

                int choice = InputValidator.ReadInt("Оберіть дію (1-5): ");

                switch (choice)
                {
                    case 1:
                        Apartment.PrintHeader();
                        for (int i = 0; i < count; i++)
                        {
                            apartments[i].Print();
                        }
                        break;

                    case 2:
                        if (count >= apartments.Length)
                        {
                            Console.WriteLine("Масив заповнений.");
                            break;
                        }

                        Apartment apt = new Apartment();
                        apt.Number = InputValidator.ReadInt("Номер квартири: ");
                        apt.Area = InputValidator.ReadDouble("Площа: ");
                        apt.Floor = InputValidator.ReadInt("Поверх: ");
                        apt.Rooms = InputValidator.ReadInt("Кількість кімнат: ");
                        apt.Type = InputValidator.ReadBuildingType();
                        apt.Lifespan = InputValidator.ReadInt("Строк експлуатації (років): ");

                        apartments[count++] = apt;
                        Console.WriteLine("Квартиру успішно додано.");
                        break;

                    case 3:
                        int targetRooms = InputValidator.ReadInt("Введіть кількість кімнат: ");
                        bool foundRooms = false;

                        Apartment.PrintHeader();
                        for (int i = 0; i < count; i++)
                        {
                            if (apartments[i].Rooms == targetRooms)
                            {
                                apartments[i].Print();
                                foundRooms = true;
                            }
                        }

                        if (!foundRooms) Console.WriteLine("Квартир за цим критерієм не знайдено.");
                        break;

                    case 4:
                        double minArea = InputValidator.ReadDouble("Мінімальна площа: ");
                        int minFloor = InputValidator.ReadInt("Квартири вище якого поверху шукати: ");
                        bool foundArea = false;

                        Apartment.PrintHeader();
                        for (int i = 0; i < count; i++)
                        {
                            if (apartments[i].Area > minArea && apartments[i].Floor > minFloor)
                            {
                                apartments[i].Print();
                                foundArea = true;
                            }
                        }

                        if (!foundArea) Console.WriteLine("Квартир за цим критерієм не знайдено.");
                        break;

                    case 5:
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Помилка: Оберіть пункт від 1 до 5.");
                        break;
                }
            }
        }
    }
}