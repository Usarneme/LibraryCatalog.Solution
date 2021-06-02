using System;

namespace Library.Models
{
  public class Checkout
  {
    public Checkout()
    {
      CheckoutId = Guid.NewGuid().ToString();
      DueDate = DateTime.Today.AddDays(21);
    }
    public string CheckoutId { get; set; }
    public string BookId { get; set; }
    public string LibraryUserId { get; set; }
    public DateTime DueDate { get; set; }
    public virtual Book Book { get; set; }
    public virtual LibraryUser LibraryUser { get; set; }
  }
}
