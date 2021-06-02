using System;

namespace Library.Models
{
  public class Checkout
  {
    public string CheckoutId { get; set; }
    public string BookId { get; set; }
    public string LibraryUserId { get; set; }
    public DateTime DueDate { get; set; }
    public virtual Book Book { get; set; }
    public virtual LibraryUser LibraryUser { get; set; }
  }
}
