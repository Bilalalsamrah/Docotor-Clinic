using AwpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwpDemo.Controllers
{
    public class AskController : Controller
    {


        public ActionResult Index()
        {
            if (Session["username"] != null && Session["username"].ToString() != "admin")
            {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();

                BussnissLayer bussnissLayer = new BussnissLayer();
                List<Asks> asks = bussnissLayer.asks.ToList();


                return View(asks);
          }
            else return RedirectToAction("Login", "Login");


        }
        public ActionResult Index2()
        {
            if (Session["username"].ToString() == "admin")
          {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();

                BussnissLayer bussnissLayer = new BussnissLayer();
                List<Asks> asks = bussnissLayer.asks.ToList();


                return View(asks);
           }
            else return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public ActionResult AsqUser()
        {
         if (Session["username"] != null && Session["username"].ToString() != "admin")
            {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
                return View();
          }
          return RedirectToAction("Login");

        }
        [HttpPost]
        public ActionResult AsqUser(Asks ask, Users users)
        {
            if (Session["username"] != null && Session["username"].ToString() != "admin")
            {
                
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
                BussnissLayer bussniss = new BussnissLayer();
                bussniss.AddQuestion(ask, Session["username"].ToString());
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login", "Login");

        }
        [HttpGet]
        public ActionResult Answar(int id)
        {
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
                BussnissLayer bussnissLayer = new BussnissLayer();
                Asks asks = bussnissLayer.asks.Single(emp => emp.Id == id);

                return View(asks);
            }
            else return RedirectToAction("Login", "Login");


        }
        [HttpPost]
        public ActionResult Answar(Asks ask)
        {
            if (Session["username"].ToString() == "admin")
            {
                ViewBag.onlineusers = "" + HttpContext.Application["OnlineUserCounter"].ToString();
                BussnissLayer bussnissLayer = new BussnissLayer();
                bussnissLayer.AddAnswar(ask);
                return RedirectToAction("Index2");
            }
            else return RedirectToAction("Login", "Login");

        }

        public ActionResult Myquestion()
        {
            if (Session["username"] != null && Session["username"].ToString()!="admin")
            {
                BussnissLayer bussnissLayer = new BussnissLayer();
                List<Asks> asks = bussnissLayer.Myquestion(Session["username"].ToString());
                return View(asks);

            }
            else return RedirectToAction("Login", "Login");
        }
        public ActionResult Waitting()
        {
            BussnissLayer bussnissLayer = new BussnissLayer();
            List<Asks> waittingquestion = bussnissLayer.WaittingQuestion().ToList();
            return View(waittingquestion);


        }


    }
}