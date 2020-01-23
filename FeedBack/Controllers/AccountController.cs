using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedBack.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVModel loginVmodel)
        {
            try
            {
                var name = "admin@gmail.com";
                var pass = "admin";
                if (ModelState.IsValid)
                {
                    if (name == loginVmodel.Email && pass == loginVmodel.Password)
                        return RedirectToAction("Index", "Home");
                    else
                        return Ok("Invalid Email or Password");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Invalid Email or Password");
            }
            return View(loginVmodel);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}