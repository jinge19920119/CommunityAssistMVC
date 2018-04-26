using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC.Models;

namespace CommunityAssistMVC.Controllers
{
    public class RegisterController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="lastName, firstName, email, password, apartmentNumber, street, city, state, zipcode, phone")]PersonRegistered pr)
        {
            Message m = new Message();
            int result = db.usp_Register(pr.lastName, pr.firstName, pr.email, pr.password, pr.apartmentNumber, pr.street, pr.city, pr.state, pr.zipcode, pr.phone);
            if(result != -1)
            {
                m.messageText = "Welcome, " + pr.firstName + " " + pr.lastName;
            } else
            {
                m.messageText = "Something went wrong.";
            }
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}