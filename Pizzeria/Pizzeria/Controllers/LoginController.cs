using Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzeria.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Pizzeria.Models.Users userModel)
        {
            using (ModelDbContext db = new ModelDbContext())
            {
                var userDetails = db.Users.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {

                    return View("Login", userModel);
                }
                else
                {
                    Session["userID"] = userDetails.IdUtente;
                    Session["userName"] = userDetails.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}