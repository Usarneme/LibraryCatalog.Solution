namespace Library.Models
{
  public class Opus
  {
    public string OpusId { get; set; }
    public string AuthorId { get; set; }
    public string BookId { get; set; }
    public virtual Author Author { get; set; }
    public virtual Book Book { get; set; }
  }
}
