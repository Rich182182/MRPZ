class Catalog
{
    public List<Book> Books { get; set; } = new List<Book>();

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        public List<string> CheckoutHistory { get; set; } = new List<string>();

        public void PrintInfo()
        {
            Console.WriteLine($"Книга: \"{Title}\", Автор: {Author} | Статус: {(IsCheckedOut ? "Видана" : "В наявності")}");
            if (CheckoutHistory.Count > 0)
            {
                Console.WriteLine("  Історія:");
                foreach (var record in CheckoutHistory)
                {
                    Console.WriteLine($"   - {record}");
                }
            }
            else
            {
                Console.WriteLine("  Історія порожня.");
            }
        }
    }
}