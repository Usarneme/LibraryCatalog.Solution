using System;
using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      ISBN = Guid.NewGuid().ToString();
      Checkouts = new HashSet<Checkout>();
      Opera = new HashSet<Opus>();
    }
    public string ISBN { get; set; } // fake, this will be a GUID
    public virtual ICollection<Checkout> Checkouts { get; }
    public virtual ICollection<Opus> Opera { get; }
    public string Title { get; set; }
  }
}
