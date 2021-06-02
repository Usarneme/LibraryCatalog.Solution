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

    [HttpGet("/books")]
    public async Task<ActionResult> Index()
    {
      var x = User.FindFirst(ClaimTypes.NameIdentifier);
      var userId = x?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      Console.WriteLine("\nHIT BOOKS INDEX ROUTE");
      Console.WriteLine("ClaimTypes.NameId {0}", x);
      Console.WriteLine($"User {userId}");
      Console.WriteLine("CURRENT USER {0}", currentUser);
      Console.WriteLine("CURRENT USERNAME {0}", currentUser.UserName);
      Console.WriteLine("Is Librarian: {0}", currentUser.IsLibrarian);

      // if(currentUser.IsLibrarian) ViewBag.
      // for everybody - 1) available books, 2) checked-out books
      // TODO
      ViewBag.currentUser = currentUser;
      ViewBag.allBooks = _db.Books.ToList();
      // if Librarian, get: 1) load patrons from checked-out books list

      // patron/everybody - get: 1) all books checked out by me
      // var userItems = _db.Items.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View();
    }

    public ActionResult Create()
    {
      // ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

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
  }
}
