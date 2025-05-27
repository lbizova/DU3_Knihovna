namespace DU3_LB_Knihovna;

class Program
{
  static List<Book> books = new List<Book>();
  static void Main(string[] args)
  {
    BasicListOfBooks();
    Console.WriteLine("Vítejte v aplikaci pro správu knihovny. ");
    while (true)
    {
      Console.WriteLine();
      Instructions();
      string input = Console.ReadLine() ?? string.Empty;
      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
        continue;
      }

      string[] inputParts = input.Split(';');
      string command = inputParts[0].ToUpper();

      switch (command)
      {
        //ADD - Přidá novou knihu do knihovny.
        case "ADD":
          AddBook(inputParts);
          break;

        //LIST - Vypíše seznam všech knih v knihovně.
        case "LIST":
          ListBooks(inputParts);
          break;

        //STATS - Vypíše statistiky o knihách v knihovně.
        case "STATS":
          StatsBooks(inputParts);
          break;

        //FIND - Vyhledá knihy podle klíčového slova v názvu.
        case "FIND":
          FindBooks(inputParts);
          break;
        //END - Ukončí program.
        case "END":
          Console.WriteLine("Program byl ukončen.");
          return;
        //Pokud uživatel zadá neplatný příkaz, vypíše se chybová zpráva.

        default:
          Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
          break;
      }
    }
  }
  private static void BasicListOfBooks()
  {
    books.AddRange(new[]
    {
    new Book("Harry Potter a Kámen mudrců", "J.K. Rowling", new DateTime(1997, 6, 26), 223),
    new Book("Harry Potter a Tajemná komnata", "J.K. Rowling", new DateTime(1998, 7, 2), 251),
    new Book("Harry Potter a vězeň z Azkabanu", "J.K. Rowling", new DateTime(1999, 7, 8), 317),
    new Book("Harry Potter a Ohnivý pohár", "J.K. Rowling", new DateTime(2000, 7, 8), 636),
    new Book("Harry Potter a Fénixův řád", "J.K. Rowling", new DateTime(2003, 6, 21), 766),
    new Book("Harry Potter a Princ dvojí krve", "J.K. Rowling", new DateTime(2005, 7, 16), 607),
    new Book("Harry Potter a Relikvie smrti", "J.K. Rowling", new DateTime(2007, 7, 21), 607),
    new Book("Z deníku kocoura Modroocka", "Josef Čapek", new DateTime(1991, 1, 1), 112),
    new Book("Knizka Ferdy Mravence", "Ondřej Sekora", new DateTime(1968, 1, 1), 184),
    new Book("Pohádkové usínání s tlapkami", "kolektiv autorů", new DateTime(2024, 1, 1), 176),
    new Book("Jaro je tady", "Anne Paschier", new DateTime(2017, 1, 1), 8),
    new Book("Krásný letní den", "Anne Paschier", new DateTime(2017, 1, 1), 8),
    new Book("Přichází podzim", "Anne Paschier", new DateTime(2017, 1, 1), 8),
    new Book("Zimní krajina", "Anne Paschier", new DateTime(2017, 1, 1), 8)
   });
  }
  private static void Instructions()
  {
    Console.WriteLine("Zadejte příkaz (ADD, LIST, STATS, FIND, END): ");
    Console.WriteLine("Nápověda: ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]");
    Console.WriteLine("FIND;[klíčové slovo]");
  }
  private static void AddBook(string[] inputParts)
  {
    if (inputParts.Length != 5)
    {
      Console.WriteLine("Neplatný počet parametrů pro přidání knihy.");
      return;
    }
    string title = inputParts[1].Trim();
    string author = inputParts[2].Trim();
    if (!DateTime.TryParseExact(inputParts[3], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None , out DateTime publishedDate))
    {
      Console.WriteLine("Neplatný formát data. Použijte formát YYYY-MM-DD.");
      return;
    }
    if (!int.TryParse(inputParts[4], out int pages))
    {
      Console.WriteLine("Neplatný počet stran. Zadejte kladné celé číslo.");
      return;
    }
    //Zkontrolujte, zda již kniha s daným názvem a autorem neexistuje.
    if (books.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)))
    {
      Console.WriteLine($"Kniha '{title}' od autora '{author}' již existuje.");
      return;
    }
    try
    {
      Book newBook = new Book(title, author, publishedDate, pages);
      books.Add(newBook);
      Console.WriteLine($"Kniha '{title}' byla přidána do knihovny.");
    }
    catch (ArgumentException ex)
    {
      Console.WriteLine($"Chyba při přidávání knihy: {ex.Message}");
    }
  }
  private static void ListBooks(string[] inputParts)
  {
    if (inputParts.Length != 1)
    {
      Console.WriteLine("Neplatný příkaz. Použijte pouze 'LIST'.");
      return;
    }
    var sortedBooks = books.OrderBy(b => b.PublishedDate);
    foreach (var book in sortedBooks)
    {
      Console.WriteLine(book.ToString());
    }
  }
  private static void StatsBooks(string[] inputParts)
  {
    if (inputParts.Length != 1)
    {
      Console.WriteLine("Neplatný příkaz. Použijte pouze 'STATS'.");
      return;
    }
    int averagePages = (int)books.Select(b => b.Pages).Average();
    var booksByAuthor = books.GroupBy(b => b.Author)
                              .Select(g => new { Author = g.Key, Count = g.Count() });
    var allWords = books.SelectMany(b => b.Title.Split(' '));
    var allWordsSmall = allWords.Select(w => w.ToLower());
    var uniqueWordsCount = allWordsSmall.Distinct().Count();
    Console.WriteLine($"Průměrný počet stran: {averagePages}");
    Console.WriteLine($"Počet knih od každého autora:");
    foreach (var author in booksByAuthor)
    {
      Console.WriteLine($"{author.Author}: {author.Count}");
    }
    Console.WriteLine($"Počet unikátních slov v názvech knih: {uniqueWordsCount}");
  }
  private static void FindBooks(string[] inputParts)
  {
    if (inputParts.Length != 2)
    {
      Console.WriteLine("Neplatný příkaz. Použijte 'FIND;[klíčové slovo]'.");
      return;
    }
    string keyword = inputParts[1].ToLowerInvariant();
    var foundBooks = books.Where(b => b.Title.ToLowerInvariant().Contains(keyword));
    if (foundBooks.Any())
    {
      Console.WriteLine($"Výsledky hledání pro '{keyword}':");
      foreach (var book in foundBooks)
      {
        Console.WriteLine(book.ToString());
      }
    }
    else
    {
      Console.WriteLine($"Žádné knihy neobsahují klíčové slovo '{keyword}'.");
    }
  }
}
