using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Library.Models;

namespace Library.Controllers
{
  [AllowAnonymous]
  public class AccountsController : Controller
  {
    [HttpGet("/accounts")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("/accounts/register")]

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]

    public IActionResult Register(string email, string name, string password)
    {
      // TODO
      return View();
    }

    [HttpGet("/accounts/login")]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
      // TODO
      return View();
    }
  }
}
