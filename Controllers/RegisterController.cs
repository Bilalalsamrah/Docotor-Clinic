using AwpDemo.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AwpDemo.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {

            //To Validate Google recaptcha
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LcmHfsUAAAAAOlnt7IhMA3lokBVrnDSY2k9G2Mi";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            //check the status is true or not
            if (status == true && ModelState.IsValid)
            {
                
           
                BussnissLayer bussnissLayer = new BussnissLayer();
                bussnissLayer.AddUser(user);

                return RedirectToAction("Login", "Login");
            }
           
            return View();
        }
    }
}
