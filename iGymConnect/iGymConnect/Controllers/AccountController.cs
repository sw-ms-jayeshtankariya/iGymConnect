﻿using BusinessLogic.ObjectModel;
using BusinessLogic.UserMag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iGymConnect.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(OMUser model)
        {
            var user = (BUser.GetByUserNameAndPassword(model).FirstOrDefault());
            if (user != null)
            {
                Session["user_login"] = user;
                 return RedirectToAction("Index", "Dashboard");
               
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

           
        }
       
    }
}