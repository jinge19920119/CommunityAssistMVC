using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC.Models;

namespace CommunityAssistMVC.Controllers
{
    public class DonationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message m = new Message("You need to login before donation. Redirecting...");
                Response.AppendHeader("Refresh", "3;url=Login");
                return View("Result", m);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, DonationDate, DonationAmount, DonationConfirmationCode")]Donation donation)
        {
            donation.DonationDate = DateTime.Now;
            donation.PersonKey = (int)Session["PersonKey"];
            donation.DonationConfirmationCode = Guid.NewGuid();
            db.Donations.Add(donation);
            db.SaveChanges();
            Message m = new Message("Thanks for your donation.");
            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}