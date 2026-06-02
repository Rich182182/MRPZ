class Program
{
    static void Main()
    {
        Console.WriteLine("Вербицький Є. В.");

        Catalog catalog = new Catalog();

        Catalog.Book initialBook = new Catalog.Book { Title = "Тіні забутих предків", Author = "Михайло Коцюбинський", IsCheckedOut = false };
        initialBook.CheckoutHistory.Add($"{DateTime.Now.AddDays(-2).ToString("dd.MM.yyyy HH:mm")} - Видано Роману");
        initialBook.CheckoutHistory.Add($"{DateTime.Now.ToString("dd.MM.yyyy HH:mm")} - Повернуто");
        catalog.Books.Add(initialBook);

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n--- МЕНЮ КАТАЛОГУ ---");
            Console.WriteLine("1. Додати нову книгу");
            Console.WriteLine("2. Видати / Повернути книгу");
            Console.WriteLine("3. Показати всі книги");
            Console.WriteLine("4. Пошук книги за назвою або автором");
            Console.WriteLine("5. Вийти");
            Console.Write("Оберіть дію (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть назву книги: ");
                    string title = Console.ReadLine();
                    Console.Write("Введіть автора книги: ");
                    string author = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author))
                    {
                        catalog.Books.Add(new Catalog.Book { Title = title, Author = author });
                        Console.WriteLine("Книгу успішно додано.");
                    }
                    else
                    {
                        Console.WriteLine("Помилка: Назва та автор не можуть бути порожніми.");
                    }
                    break;

                case "2":
                    Console.Write("Введіть назву книги для видачі або повернення: ");
                    string searchTitle = Console.ReadLine();

                    List<Catalog.Book> foundBooks = new List<Catalog.Book>();

                    foreach (var book in catalog.Books)
                    {
                        if (book.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase))
                        {
                            foundBooks.Add(book);
                        }
                    }

                    if (foundBooks.Count == 0)
                    {
                        Console.WriteLine("Книгу з такою назвою не знайдено.");
                    }
                    else
                    {
                        Catalog.Book selectedBook = null;

                        if (foundBooks.Count == 1)
                        {
                            selectedBook = foundBooks[0];
                        }
                        else
                        {
                            Console.WriteLine("Знайдено кілька книг:");
                            for (int i = 0; i < foundBooks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}:");
                                foundBooks[i].PrintInfo();
                            }

                            Console.Write($"Оберіть номер книги (1-{foundBooks.Count}): ");
                            if (int.TryParse(Console.ReadLine(), out int bookIndex) && bookIndex >= 1 && bookIndex <= foundBooks.Count)
                            {
                                selectedBook = foundBooks[bookIndex - 1];
                            }
                            else
                            {
                                Console.WriteLine("Помилка: Невірний вибір.");
                            }
                        }

                        if (selectedBook != null)
                        {
                            string currentTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

                            if (selectedBook.IsCheckedOut)
                            {
                                
                                selectedBook.CheckoutHistory.Add($"{currentTime} - Повернуто");
                                selectedBook.IsCheckedOut = false;
                                Console.WriteLine("Книгу успішно повернуто.");
                            }
                            else
                            {
                                Console.Write("Введіть ім'я того, кому видається книга: ");
                                var name = Console.ReadLine();
                                selectedBook.CheckoutHistory.Add($"{currentTime} - Видано {name}");
                                selectedBook.IsCheckedOut = true;
                                Console.WriteLine("Книгу успішно видано.");
                            }
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("\nПовний список книг у каталозі:");
                    foreach (var book in catalog.Books)
                    {
                        book.PrintInfo();
                    }
                    break;

                case "4":
                    Console.Write("Введіть ключове слово для пошуку (назва або автор): ");
                    string query = Console.ReadLine();
                    bool foundSearch = false;

                    Console.WriteLine("\nРезультати пошуку:");
                    foreach (var book in catalog.Books)
                    {
                        if (book.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            book.Author.Contains(query, StringComparison.OrdinalIgnoreCase))
                        {
                            book.PrintInfo();
                            foundSearch = true;
                        }
                    }

                    if (!foundSearch)
                    {
                        Console.WriteLine("За вашим запитом нічого не знайдено.");
                    }
                    break;

                case "5":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Помилка: Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}