using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC.Models;
namespace CommunityAssistMVC.Controllers
{
    public class GrantController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Grant
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message msg = new Message("You must be logged in to apply for a grant. Redirecting...");
                Response.AppendHeader("Refresh", "3;url=Login");
                return View("Result", msg);
            }
            ViewBag.GrantType = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, GrantAppicationDate, GrantApplicationStatusKey, GrantApplicationReason, GrantApplicationRequestAmount, GrantType")]GrantApplication ga)
        {
            Message m = new Message();
            try
            {
                ga.PersonKey = (int)Session["PersonKey"];
                ga.GrantAppicationDate = DateTime.Now;
                ga.GrantApplicationStatusKey = 1;
                db.GrantApplications.Add(ga);
                db.SaveChanges();
                m.messageText = "Thank you for your application.";
            }
            catch (Exception e)
            {
                m.messageText = e.Message;
            }
            return RedirectToAction("Result", m);
        }
        public ActionResult Result(Message message)
        {
            return View(message);
        }
    }
}
