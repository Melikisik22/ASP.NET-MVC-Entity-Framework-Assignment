using System;
using System.Linq;
using System.Web.Mvc;
using InsuranceQuoteApp.Models;

namespace InsuranceQuoteApp.Controllers
{
    public class InsureeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,FullCoverage")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                decimal monthly = 50m; 

                
                int age = 0;
                if (insuree.DateOfBirth.HasValue)
                {
                    var today = DateTime.Today;
                    age = today.Year - insuree.DateOfBirth.Value.Year;
                    if (insuree.DateOfBirth.Value.Date > today.AddYears(-age)) age--;
                }

                
                if (age <= 18) monthly += 100m;
                else if (age >= 19 && age <= 25) monthly += 50m;
                else monthly += 25m; 

                
                if (insuree.CarYear < 2000) monthly += 25m;
                if (insuree.CarYear > 2015) monthly += 25m;

                
                if (!string.IsNullOrEmpty(insuree.CarMake) && insuree.CarMake.ToLower().Trim() == "porsche")
                {
                    monthly += 25m;
                    if (!string.IsNullOrEmpty(insuree.CarModel) && insuree.CarModel.ToLower().Trim() == "911 carrera")
                    {
                        monthly += 25m;
                    }
                }

                
                monthly += 10m * insuree.SpeedingTickets;

                
                if (insuree.DUI) monthly *= 1.25m;

                
                if (insuree.FullCoverage) monthly *= 1.5m;

                insuree.Quote = Math.Round(monthly, 2);

                db.Insurees.Add(insuree);
                db.SaveChanges();

                return RedirectToAction("Admin");
            }

            return View(insuree);
        }

        
        public ActionResult Admin()
        {
            var list = db.Insurees.ToList();
            return View(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
