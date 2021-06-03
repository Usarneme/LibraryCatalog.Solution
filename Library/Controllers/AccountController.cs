using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Library.Models;
using Library.ViewModels;

namespace Library.Controllers
{
  [AllowAnonymous]
  public class AccountController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<LibraryUser> _userManager;
    private readonly SignInManager<LibraryUser> _signInManager;
    public AccountController(UserManager<LibraryUser> userManager, SignInManager<LibraryUser> signInManager, LibraryContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public async Task<LibraryUser> GetUser() => await _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

    [HttpGet("/account")]
    public async Task<ActionResult> Index()
    {
      LibraryUser u = await GetUser();
      ViewBag.user = u;
      if (u != null)
      {
        List<Checkout> checkouts = _db.Checkouts
          .Where(c => c.LibraryUserId == u.Id)
          .Include(c => c.Book)
          .ToList();
        ViewBag.checkouts = checkouts;
      }
      return View();
    }

    [HttpGet("/account/register")] public ActionResult Register() => View();

    [HttpPost("account/register")]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      Console.WriteLine("HIT REGISTER POST ROUTE");
      var user = new LibraryUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      Console.WriteLine(result.ToString());
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpGet("/account/login")]
    public ActionResult Login() => View();

    [HttpPost("/account/login")]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost("/account/logout{message}")]
    public async Task<ActionResult> LogOut(string message)
    {
      Console.WriteLine("SIGN OUT: {0}", message);
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}
