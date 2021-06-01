using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Library.Models;
using Library.ViewModels;

namespace Library.Controllers
{
  [AllowAnonymous]
  public class AccountsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<Patron> _userManager;
    private readonly SignInManager<Patron> _signInManager;
    public AccountsController(UserManager<Patron> userManager, SignInManager<Patron> signInManager, LibraryContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    [HttpGet("/account")]
    public IActionResult Index() => View();

    [HttpGet("/account/register")]
    public IActionResult Register() => View();

    [HttpPost("account/register")]
    public async Task<ActionResult> Register(RegisterViewModel model)
    {
      Console.WriteLine("HIT REGISTER POST ROUTE");
      var user = new Patron { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
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
    public IActionResult Login()
    {
      return View();
    }

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

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index");
    }
  }
}
