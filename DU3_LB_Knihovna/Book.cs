using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DU3_LB_Knihovna
{
  public class Book
  {
    //bude mít následující vlastnosti:
    //Title (string) – název knihy
    public string Title { get; set; }
    //Author (string) – autor knihy
    public string Author { get; set; }
    //PublishedDate (DateTime) – datum vydání
    public DateTime PublishedDate { get; set; }
    //Pages (int) – počet stran
    private int pages;
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
    public Book(string title, string author, DateTime publishedDate, int pages)
    {
      Title = title;
      Author = author;
      PublishedDate = publishedDate;
      Pages = pages;
    }
    //Konstruktor, který inicializuje všechny vlastnosti

  }
}