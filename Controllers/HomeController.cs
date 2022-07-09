using AwpDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace AwpDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //home page for non regester in website
        public ActionResult Index()
        {
            ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
            BussnissLayer bussnissLayer = new BussnissLayer();
                List<Articles> articles = bussnissLayer.articles.ToList();



                return View(articles);
           
           
}
        
         [HttpGet]
        public ActionResult Details(int id)
        {
           
            ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
            BussnissLayer bussnissLayer = new BussnissLayer();
            
            Articles aritcle = bussnissLayer.articles.Single(emp => emp.Id == id);


                bussnissLayer.Increament(id);



            

            return View(aritcle);
        }
        // home page for user 
        public ActionResult Index1()
        {
            if(Session["username"] != null && Session["username"].ToString()!="admin")
            {
            ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
            BussnissLayer bussnissLayer = new BussnissLayer();
                List<Articles> articles = bussnissLayer.articles.ToList();



                return View(articles);
           }
           else
                return RedirectToAction("Login","Login");

        }



       
      
        public ActionResult Logout()
        {
            Session["username"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
        // home page for admin
        public ActionResult Index2()
        {
            ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
            if ((string)Session["username"] == "admin")
            {
            BussnissLayer bussnissLayer = new BussnissLayer();
                List<Articles> articles = bussnissLayer.articles.ToList();

                return View(articles);

            }
           else
             return RedirectToAction("Login", "Login");
        
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();

            return View();
        }
        [HttpPost]
       
        public ActionResult Create(Articles articles)
        {
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
                
                    BussnissLayer bussnissLayer = new BussnissLayer();

                    bussnissLayer.AddArticle(articles);
                    return RedirectToAction("Index2", "Home");
              
            }
            else return RedirectToAction("Login", "Login");

        }
        [HttpGet]
        public ActionResult Edit(int id)

        {
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
                BussnissLayer bussnissLayer = new BussnissLayer();
                Articles articles = bussnissLayer.articles.Single(emp => emp.Id == id);
                return View(articles);


            }
        else return RedirectToAction("Login", "Login");
        
        
        }
        [HttpPost]
        public ActionResult Edit()
        {
            BussnissLayer bussnissLayer = new BussnissLayer();
            return RedirectToAction("Index2");

        }

        [HttpPost]
        public ActionResult Delete(int id )

        {
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
                BussnissLayer bussnissLayer = new BussnissLayer();

                bussnissLayer.Delete(id);
                return RedirectToAction("Index2", "Home");
            }
            else return RedirectToAction("Login", "Login");
          

        }
        


    }
}