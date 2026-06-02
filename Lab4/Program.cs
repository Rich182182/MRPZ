using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Вербицький Є. В.");

        Console.Write("Введіть шлях до вхідного файлу (наприклад, input.txt): ");
        string inputPath = Console.ReadLine();

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Файл не знайдено. Створюється автоматично тестовий файл за шляхом: {inputPath}");
            string[] sampleContent = new[]
            {
                "Перший рядок для перевірки нашої програми.",
                "Другий рядок містить трохи більше різних слів.",
                "Третій рядок також знаходиться прямо тут.",
                "Четвертий і останній рядок нашого тестового файлу."
            };
            try
            {
                File.WriteAllLines(inputPath, sampleContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка створення файлу: {ex.Message}");
                return;
            }
        }

        Console.Write("Введіть шлях до вихідного файлу (наприклад, output.txt): ");
        string outputPath = Console.ReadLine();

        Console.Write("Введіть кількість останніх рядків (k): ");
        int k;
        while (!int.TryParse(Console.ReadLine(), out k) || k < 0)
        {
            Console.Write("Помилка. Введіть додатне число (k): ");
        }

        Console.Write("Введіть кількість останніх слів (m): ");
        int m;
        while (!int.TryParse(Console.ReadLine(), out m) || m < 0)
        {
            Console.Write("Помилка. Введіть додатне число (m): ");
        }

        try
        {
            Console.WriteLine("Відкриття та читання вхідного файлу...");
            string[] lines = File.ReadAllLines(inputPath);

            int startLine = Math.Max(0, lines.Length - k);

            Console.WriteLine("Обробка даних та запис у вихідний файл...");
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                for (int i = startLine; i < lines.Length; i++)
                {
                    string[] words = lines[i].Split(new[] { ' ', '\t', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    int startWord = Math.Max(0, words.Length - m);

                    for (int j = startWord; j < words.Length; j++)
                    {
                        writer.Write(words[j] + (j == words.Length - 1 ? "" : " "));
                    }
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Готово! Результат успішно збережено.");

            Console.WriteLine("\nВміст вихідного файлу:");
            Console.WriteLine(File.ReadAllText(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при обробці: {ex.Message}");
        }
    }
}