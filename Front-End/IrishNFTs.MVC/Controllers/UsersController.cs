using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace IrishNFTs.MVC.Controllers;

public class UsersController : Controller
{

    // [Authorize(Roles = "Admin")]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "Admin")]
    public IActionResult EditUsers()
    {
        return View();
    }

}


