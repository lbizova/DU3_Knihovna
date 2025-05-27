namespace DU3_LB_Knihovna;

class Program
{
  static void Main(string[] args)
  {
    //  Console.WriteLine("Hello, World!");
    Book harryPotter1 = new Book("Harry Potter a Kámen mudrců", "J.K. Rowling", new DateTime(1997, 6, 26), 223);
    Book harryPotter2 = new Book("Harry Potter a Tajemná komnata", "J.K. Rowling", new DateTime(1998, 7, 2), 251);
    Book harryPotter3 = new Book("Harry Potter a vězeň z Azkabanu", "J.K. Rowling", new DateTime(1999, 7, 8), 317);
    Book harryPotter4 = new Book("Harry Potter a Ohnivý pohár", "J.K. Rowling", new DateTime(2000, 7, 8), 636);
    Book harryPotter5 = new Book("Harry Potter a Fénixův řád", "J.K. Rowling", new DateTime(2003, 6, 21), 766);
    Book harryPotter6 = new Book("Harry Potter a Princ dvojí krve", "J.K. Rowling", new DateTime(2005, 7, 16), 607);
    Book harryPotter7 = new Book("Harry Potter a Relikvie smrti", "J.K. Rowling", new DateTime(2007, 7, 21), 607);
    Book zDenikuKocouraModrocka = new Book("Z deníku kocoura Modroocka", "Josef Čapek", new DateTime(1991, 1, 1), 112);
    Book knizkaFerdyMravence = new Book("Knizka Ferdy Mravence", "Ondřej Sekora", new DateTime(1968, 1, 1), 184);
    Book pohadkoveUsinaniSTlapkami = new Book("Pohádkové usínání s tlapkami", "kolektiv autorů", new DateTime(2024, 1, 1), 176);
    Book jaroJeTady = new Book("Jaro je tady", "Anne Paschier", new DateTime(2017, 1, 1), 8);
    Book krasnyLetniDen = new Book("Krásný letní den", "Anne Paschier", new DateTime(2017, 1, 1), 8);
    Book prichaziPodzim = new Book("Přichází podzim", "Anne Paschier", new DateTime(2017, 1, 1), 8);
    Book zimniKrajina = new Book("Zimní krajina", "Anne Paschier", new DateTime(2017, 1, 1), 8);

    List<Book> books = new List<Book>
    {
      harryPotter1,
      harryPotter2,
      harryPotter3,
      harryPotter4,
      harryPotter5,
      harryPotter6,
      harryPotter7,
      zDenikuKocouraModrocka,
      knizkaFerdyMravence,
      pohadkoveUsinaniSTlapkami,
      jaroJeTady,
      krasnyLetniDen,
      prichaziPodzim,
      zimniKrajina
    };
    System.Console.WriteLine("Vítejte v aplikaci pro správu knihovny. ");
    //string input;
    //string[] inputParts;

    while (true)
    {
      System.Console.WriteLine(); 
      Instructions();
      string input = Console.ReadLine();
      if (string.IsNullOrWhiteSpace(input))
      {
        System.Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
        continue;
      }

      string[] inputParts = input.Split(';');
      //kontrola správného počtu argumentů
      string command = inputParts[0].ToUpper();
      try
      {
        if (command == "ADD" && inputParts.Length != 5)
        {
          System.Console.WriteLine("Neplatný počet parametrů pro přidání knihy.");
          continue;
        }
        else if (command == "LIST" && inputParts.Length != 1)
        {
          System.Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
          continue;
        }
        else if (command == "STATS" && inputParts.Length != 1)
        {
          System.Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
          continue;
        }
        else if (command == "FIND" && inputParts.Length != 2)
        {
          System.Console.WriteLine("Zadej klíčové slovo pro hledání.");
          continue;
        }
        else if (command == "END" && inputParts.Length != 1)
        {
          System.Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
          continue;
        }
      }
      catch (Exception ex)
      {
        
        System.Console.WriteLine($"Došlo k chybě: {ex.Message}");
        continue;
      }

      //Program bude opakovaně číst vstup z konzole. Vstup může být jeden z následujících:

      //ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]
      if (inputParts[0].ToUpper() == "ADD")
      {
        string title = inputParts[1].Trim();
        if (string.IsNullOrWhiteSpace(title))
        {
          System.Console.WriteLine("Název knihy nesmí být prázdný.");
          continue;
        }
        string author = inputParts[2].Trim();
        if (string.IsNullOrWhiteSpace(author))
        {
          System.Console.WriteLine("Autor knihy nesmí být prázdný.");
          continue;
        }
        if (!DateTime.TryParse(inputParts[3], out DateTime publishedDate))
        {
          System.Console.WriteLine("Neplatný formát data. Použijte formát YYYY-MM-DD.");
          continue;
        }
        if (!int.TryParse(inputParts[4], out int pages) || pages <= 0)
        {
          System.Console.WriteLine("Neplatný počet stran. Zadejte kladné celé číslo.");
          continue;
        }
        //Zkontrolujte, zda již kniha s daným názvem a autorem neexistuje.
        if (books.Any(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)))
        {
          System.Console.WriteLine($"Kniha '{title}' od autora '{author}' již existuje.");
          continue;
        }
        try
        {
          Book newBook = new Book(title, author, publishedDate, pages);
          books.Add(newBook);
          System.Console.WriteLine($"Kniha '{title}' byla přidána do knihovny.");
        }
        catch (ArgumentException ex)
        {
          System.Console.WriteLine($"Chyba při přidávání knihy: {ex.Message}");
        }
      }
      //LIST - Vypíše všechny knihy, seřazené podle data vydání. Použijte OrderBy
      else if (inputParts[0].ToUpper() == "LIST")
      {
        var sortedBooks = books.OrderBy(b => b.PublishedDate);
        foreach (var book in sortedBooks)
        {
          System.Console.WriteLine($"Kniha: {book.Title}, autor: {book.Author}, vydáno {book.PublishedDate.ToString("d.M.yyyy")}, Počet stran: {book.Pages}");
        }
      }
      //STATS - Vypíše:
      else if (inputParts[0].ToUpper() == "STATS")
      {
        //Průměrný počet stran (použijte Select a Average)
        int averagePages = (int)books.Select(b => b.Pages).Average();
        //Počet knih od každého autora (použijte GroupBy)
        var booksByAuthor = books.GroupBy(b => b.Author)
                                  .Select(g => new { Author = g.Key, Count = g.Count() });
        //Počet unikatních slov v názvech knih. Použijte SelectMany a rozdělení názvů podle mezer (interpunkci vynechte) pro vytvoření jednoho seznamu všech slov, pak použijte Distinct.
        var allWords = books.SelectMany(b => b.Title.Split(' '));
        var allWordsSmall = allWords.Select(w => w.ToLower());
        var uniqueWordsCount = allWordsSmall.Distinct().Count();
        System.Console.WriteLine($"Průměrný počet stran: {averagePages}");
        System.Console.WriteLine($"Počet knih od každého autora:");
        foreach (var author in booksByAuthor)
        {
          System.Console.WriteLine($"{author.Author}: {author.Count}");
        }
        System.Console.WriteLine($"Počet unikátních slov v názvech knih: {uniqueWordsCount}");

      }
      //FIND;[klíčové slovo] - Vyhledá knihy, jejichž název obsahuje dané slovo, bez ohledu na velikost písmen (použijte Where).
      else if (inputParts[0].ToUpper() == "FIND")
      {
        string keyword = inputParts[1].ToLower();
        var foundBooks = books.Where(b => b.Title.ToLower().Contains(keyword));
        if (foundBooks.Any())
        {
          System.Console.WriteLine($"Výsledky hledání pro '{keyword}':");
          foreach (var book in foundBooks)
          {
            System.Console.WriteLine(book.Title);
          }
        }
        else
        {
          System.Console.WriteLine($"Žádné knihy neobsahují klíčové slovo '{keyword}'.");
        }
      }
      //END - Ukončí program.
      else if (inputParts[0].ToUpper() == "END")
      {
        System.Console.WriteLine("Program byl ukončen.");
        return;
      }
      else
      {
        System.Console.WriteLine("Neplatný příkaz. Zkuste to znovu.");
      }
    }
  }

  private static void Instructions()
  {
    System.Console.WriteLine("Zadejte příkaz (ADD, LIST, STATS, FIND, END): ");
    System.Console.WriteLine("Nápověda: ADD;[název];[autor];[datum vydání ve formátu YYYY-MM-DD];[počet stran]");
    System.Console.WriteLine("FIND;[klíčové slovo]");
  }
}
