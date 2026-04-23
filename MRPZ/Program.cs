using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Вербицький Є. В.");

        Console.Write("Введіть розмір матриці n: ");
        int n = int.Parse(Console.ReadLine());

        int[,] a = new int[n, n];

        Console.WriteLine("Введіть елементи матриці по рядках:");
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < n; j++)
            {
                a[i, j] = int.Parse(input[j]);
            }
        }

        Console.WriteLine("\nМатриця А:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(a[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int sum = 0;
        for (int j = 0; j < n; j++)
        {
            sum += a[0, j];
        }

        bool isMagic = true;

        for (int i = 0; i < n; i++)
        {
            int rowSum = 0;
            int colSum = 0;
            for (int j = 0; j < n; j++)
            {
                rowSum += a[i, j];
                colSum += a[j, i];
            }
            if (rowSum != sum || colSum != sum)
            {
                isMagic = false;
            }
        }

        int diag1 = 0;
        int diag2 = 0;
        for (int i = 0; i < n; i++)
        {
            diag1 += a[i, i];
            diag2 += a[i, n - 1 - i];
        }

        if (diag1 != sum || diag2 != sum)
        {
            isMagic = false;
        }

        if (isMagic)
        {
            Console.WriteLine("Магічне число: " + sum);
        }
        else
        {
            Console.WriteLine("Матриця не є магічним квадратом.");
        }
    }
}