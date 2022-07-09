using AwpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwpDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login( )
            
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)

        {
          
           
                BussnissLayer bussnissLayer = new BussnissLayer();
                int i = bussnissLayer.Login(user);

                if (i == 1)
                {
                
                    Session["username"] = user.Name;
                    switch (Session["username"].ToString())
                    {
                        case "admin":
                            return RedirectToAction("index2", "Home");

                        default:
                            return RedirectToAction("Index1", "Home");

                    }


                }
                else
                    return RedirectToAction("Login");



            }       
    }
}