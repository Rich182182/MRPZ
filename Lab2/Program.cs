using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Вербицький Є. В.");

        Random rand = new Random();
        string[] nums = new string[3];

        Console.WriteLine("Згенеровані числа для першого завдання:");
        for (int i = 0; i < 3; i++)
        {
            nums[i] = rand.Next(10, 10000).ToString();
            Console.Write(nums[i] + " ");
        }
        Console.WriteLine();

        char maxDigit = '0';
        for (int i = 0; i < 3; i++)
        {
            if (nums[i][0] > maxDigit)
            {
                maxDigit = nums[i][0];
            }
        }
        Console.WriteLine("Найбільша перша цифра: " + maxDigit);

        string text = "Текст для перевірки коду. Тут є великі слова і малі.";
        Console.WriteLine("\nПочатковий текст для другого завдання:");
        Console.WriteLine(text);

        string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        int minLen = int.MaxValue;
        foreach (string w in words)
        {
            if (w.Length < minLen)
            {
                minLen = w.Length;
            }
        }

        Console.WriteLine("\nСлова мінімальної довжини:");
        foreach (string w in words)
        {
            if (w.Length == minLen)
            {
                Console.WriteLine(w);
            }
        }
    }
}