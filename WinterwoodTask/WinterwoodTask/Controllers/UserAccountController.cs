using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WinterwoodTask.Models;

namespace WinterwoodTask.Models
{
    public class UserAccountController : Controller
    {
        // GET: UserAccount
       // public ActionResult Index()
       // {
           // return View();
      //  }

    
            public ActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Register(UserAccount account)
            {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.UserAccount.Add(account);
                    Session["Username"] = account.Username;
                    Session["UserID"] = account.UserID;
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " account successfully registered.";
            
            }
            if (Session["Username"] != null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(UserAccount user)
        {
            
            
                using (OurDbContext db = new OurDbContext())
                {

                    var usr = db.UserAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                    if (usr != null)
                    {
                        Session["UserID"] = user.UserID.ToString();
                        Session["Username"] = user.Username.ToString();
                        return RedirectToAction("../Batches/Index");
                        //return View();
                    }

                    else
                    {
                        ModelState.AddModelError("", "Username or Password is wrong.");
                    }
                return View(user);
            }
                
            
        }
            //public ActionResult LoggedIn()
            //{
            //    if (Session["UserID"] != null)
            //    {
            //        return View();
            //    }
            //    else
            //    {
            //        return RedirectToAction("Login");
            //    }
            //}
        }
    }

