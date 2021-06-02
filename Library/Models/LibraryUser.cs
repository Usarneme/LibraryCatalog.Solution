using Microsoft.AspNetCore.Identity;

namespace Library.Models
{
  public class LibraryUser : IdentityUser
  {
    public LibraryUser() : base() {
      IsLibrarian = false;
    }
    public bool IsLibrarian { get; set; }
  }
}
