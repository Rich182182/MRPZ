using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Apartment
    {
        public int Number { get; set; }
        public double Area { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public BuildingType Type { get; set; }
        public int Lifespan { get; set; }

        public static void PrintHeader()
        {
            Console.WriteLine($"{"Номер",-8} | {"Площа",-8} | {"Поверх",-8} | {"Кімнати",-8} | {"Тип будівлі",-15} | {"Строк експл.",-12}");
            Console.WriteLine(new string('-', 72));
        }

        public void Print()
        {
            Console.WriteLine($"{Number,-8} | {Area,-8} | {Floor,-8} | {Rooms,-8} | {Type,-15} | {Lifespan,-12}");
        }
    }
}
