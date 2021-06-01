using System;
using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      AuthorId = Guid.NewGuid().ToString();
      Opera = new HashSet<Opus>();
    }
    public string AuthorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Opus> Opera { get; }
  }
}
