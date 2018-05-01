using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.Mvc;
using System.Diagnostics;
using CommunityAssistMVC.Models;

namespace CommunityAssistMVC.Controllers
{
    public class LoginController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="userName, password")]PersonLogin pl)
        {
            int res = db.usp_Login(pl.userName, pl.password);
            int personKey = 0;
            Message message = new Message();
            if(res==-1)
            {
                message.messageText = "Invalid login.";
                Response.AddHeader("Refresh", "3;url=login");
            } else
            {
                var pkey = (from r in db.People where r.PersonEmail.Equals(pl.userName) select r.PersonKey).FirstOrDefault();
                var firstName = (from r in db.People where r.PersonEmail.Equals(pl.userName) select r.PersonFirstName).FirstOrDefault();
                personKey = (int)pkey;
                Session["PersonKey"] = personKey;
                
                message.messageText = "Welcome " + (string)firstName;
            }
            return View("Result", message);
            
        }

        public ActionResult Result(Message message)
        {
            return View(message);
        }
    }
}