using System;
using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      BookId = Guid.NewGuid().ToString();
      Checkouts = new HashSet<Checkout>();
      Opera = new HashSet<Opus>();
    }
    public string BookId { get; set; }
    public virtual ICollection<Checkout> Checkouts { get; }
    public virtual ICollection<Opus> Opera { get; }
    public string Title { get; set; }
  }
}
