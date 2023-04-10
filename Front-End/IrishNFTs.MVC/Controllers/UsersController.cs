using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IrishNFTs.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace IrishNFTs.MVC.Controllers;

public class UsersController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles = "Administrator")]
    public IActionResult EditUsers()
    {
        return View();
    }

}


