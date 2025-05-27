using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DU3_LB_Knihovna
{
  public class Book
  {
    //bude mít následující vlastnosti:
    //Title (string) – název knihy
    private string title = string.Empty; // soukromá proměnná pro název knihy 
    public string Title
    {
      get
      {
        return title;
      }
      private set // Pouze pro čtení zvenčí, ale lze nastavit uvnitř třídy
      {
        if (string.IsNullOrWhiteSpace(value))
          {
            throw new ArgumentException("Název knihy nesmí být prázdný.");
          }
        title = value;
      }
    }

    //Author (string) – autor knihy
    private string author = string.Empty; // soukromá proměnná pro autora knihy
    public string Author
    {
      get
      {
        return author;
      }
      private set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Autor knihy nesmí být prázdný.");
        }
        author = value;
      }
    }

    //PublishedDate (DateTime) – datum vydání
    public DateTime PublishedDate { get; set; }

    //Pages (int) – počet stran
    private int pages; // soukromá proměnná pro počet stran
    public int Pages
    {
      get
      {
        return pages;
      }
      private set
      {
        if (value <= 0)
        {
          throw new ArgumentException("Počet stran musí být kladný.");
        }
        pages = value;
      }

    }
    public Book(string title, string author, DateTime publishedDate, int pages) // Konstruktor, který inicializuje všechny vlastnosti
    {
      Title = title;
      Author = author;
      PublishedDate = publishedDate;
      Pages = pages;
    }
    public override string ToString() // Přepsání metody ToString pro lepší výstup informací o knize
    {
      return $"Kniha: {Title}, autor: {Author}, vydáno {PublishedDate:d.M.yyyy}, Počet stran: {Pages}";
    }

  }
}