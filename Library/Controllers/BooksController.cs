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
    private readonly UserManager<Patron> _userManager;
    public BooksController(UserManager<Patron> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpGet("/books")]
    public async Task<ActionResult> Index()
    {
      Console.WriteLine("HIT BOOKS INDEX ROUTE");
      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      Console.WriteLine($"User {userId}");
      Console.WriteLine($"{User.FindFirst(ClaimTypes.NameIdentifier)}");
      
      var currentUser = await _userManager.FindByIdAsync(userId);
      Console.WriteLine(currentUser);
      // for everybody - 1) available books, 2) checked-out books
      // TODO
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

    // [HttpPost]
    // public async Task<ActionResult> Create(Book b, string AuthorId)
    // {
    //   var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //   var currentUser = await _userManager.FindByIdAsync(userId);
    //   item.User = currentUser;
    //   _db.Items.Add(item);
    //   _db.SaveChanges();
    //   if (AuthorId != 0) _db.Opera.Add(new Opus() { 
    //     AuthorId = AuthorId, 
    //     BookId = b.BookId 
    //   });

    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}
