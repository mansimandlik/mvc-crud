using practicemvc.Models;
using practicemvc.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practicemvc.Controllers
{
    public class HiringController : Controller
    {
        // GET: login
        public ActionResult AllInterns()
        {
            Recruit RR = new Recruit();
            /*List<Recruitment> R = new List<Recruitment>
            {
                new Recruitment{ intern="pooja", Intern_id=2, address="nasik",technology=".net",experience=2},
                new Recruitment{ intern="pranav", Intern_id=1,address="nagpur",technology="angular",experience=1},
                new Recruitment{ intern="janhavi", Intern_id=3,address="nasik",technology=".net",experience=3},
                new Recruitment{ intern="prakrit", Intern_id=4,address="mumbai",technology="flutter",experience=2}
            };
            return View(R);*/
            ViewBag.val = RR.GetAllInterns();
            return View();
        }

        public ActionResult Update()
        {
            //Recruit RR = new Recruit();
           // ViewBag.val = RR.GetAllInterns();

            return View();
        }
        [HttpPost]
        public ActionResult Update(Recruitment r)
        {
            Recruitment e = new Recruitment();
            e.intern = r.intern;
            e.Intern_id = r.Intern_id;
            e.address = r.address;
            e.technology = r.technology;
            e.experience = r.experience;
            Recruit rr = new Recruit();
            rr.UpdateEmployee(e);
            
            TempData["msg"] = "Record Updated";
            return RedirectToAction("AllInterns");

        }
        public ActionResult Delete()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Recruit rr = new Recruit();
            rr.DeleteEmployee(id);
            return RedirectToAction("AllInterns");
        }
        public ActionResult Create()
        {
         
            ViewBag.Title = "Create";

            return View();
        }
        [HttpPost]
        public ActionResult Create(Recruitment r)
        {
           
            Recruitment e = new Recruitment();
            e.intern = r.intern;
            e.Intern_id =r.Intern_id;
            e.address = r.address;
            e.technology = r.technology;
            e.experience = r.experience;
            Recruit rr = new Recruit();
            rr.AddEmployee(e);
            ViewBag.Title = "Create";
            TempData["msg"] = "Record Inserted";
            return RedirectToAction("AllInterns");
        }
        
    }
}