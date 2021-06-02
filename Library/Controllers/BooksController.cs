using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
  [Authorize]
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<LibraryUser> _userManager;
    public BooksController(UserManager<LibraryUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<LibraryUser> GetUser() => await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    public Book GetBook(string id) => _db.Books.FirstOrDefault(b => b.BookId == id);


    [HttpGet("/books")]
    public async Task<ActionResult> Index()
    {
      ViewBag.user = await GetUser();
      ViewBag.allBooks = _db.Books.ToList();
      return View();
    }

    public ActionResult Create() => View();

    [HttpPost]
    // public async Task<ActionResult> Create(Book b)
    public ActionResult Create(Book b)
    {
      _db.Books.Add(b);
      _db.SaveChanges();
      // if (AuthorId != 0) _db.Opera.Add(new Opus() { 
      //   AuthorId = AuthorId, 
      //   BookId = b.BookId 
      // });
      // _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/books/{BookId}")]
    public async Task<ActionResult> Details(string BookId)
    {
      Book thisBook = GetBook(BookId);
      ViewBag.user = await GetUser();
      Console.WriteLine(ViewBag.user);
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Checkout(string BookId, string LibraryUserId)
    {
      Checkout c = new() { BookId = BookId, LibraryUserId = LibraryUserId };
      _db.Checkouts.Add(c);
      Book thisBook = GetBook(BookId);
      --thisBook.Copies;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
