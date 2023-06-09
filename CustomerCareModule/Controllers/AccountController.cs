﻿using CustomerCareModule.BAL;
using CustomerCareModule.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCareModule.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService accountService;


        public AccountController(IAccountService _accountService)
        {
            this.accountService = _accountService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid == true)
            {
                //AccountService accountService = new AccountService();
                var userViewModel = accountService.GetUser(model);

                if(userViewModel.RoleId != null)
                {
                    HttpContext.Session.SetString("Name", userViewModel.Name);
                    HttpContext.Session.SetInt32("UserId", userViewModel.Id);

                    if(userViewModel.RoleId== 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    if (userViewModel.RoleId == 2)
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    if (userViewModel.RoleId == 3)
                    {
                        return RedirectToAction("Index", "CustomerCare");
                    }
                    if (userViewModel.RoleId == 4)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }

                TempData["WrongCredential"] = "Email id or password is wrong";

            }

            return View();   
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index","Home");
        }
    }
}
