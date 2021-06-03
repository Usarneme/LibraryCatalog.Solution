using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Library.Models
{
  public class LibraryUser : IdentityUser
  {
    public LibraryUser() : base()
    {
      IsLibrarian = false;
      Checkouts = new HashSet<Checkout>();
    }
    public bool IsLibrarian { get; set; }
    public virtual ICollection<Checkout> Checkouts { get; }
  }
}
