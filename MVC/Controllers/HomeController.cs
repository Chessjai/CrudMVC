using Question2library.DbcontextCLASS;
using Question2library.Dbmodel;
using Question2library.Repositories;
using Question2library.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        DefaultDbcontext db = new DefaultDbcontext();
        Istudent istudent = null;
        public HomeController()
        {
            istudent=new StudentRepo();
        }

        public ActionResult Index()
        {
            var _data=istudent.ReadAll();
            return View(_data.studentDatas);
        }
        public ActionResult ReadByID(long ID)
        {
            var del = db._studentDbModels.Where(x => x.Id == ID).FirstOrDefault();
            var _data = istudent.Read(del.Id);
            return View(_data.studentDStudentViewModels1);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentViewModels model)
        {
            istudent.Create(model);
            return View();
          
        }
           public ActionResult Edit(long id)
        {

            var std=db._studentDbModels.Where(x=>x.Id==id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Edit(StudentViewModels model)
        {
            if (ModelState.IsValid==true)
            {

                istudent.Update(model.Id,model);
                TempData["UpdateMessage"] = model.errormessage;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.UpdateMessage= model.errormessage;
                return View();
            }

        }

        //api/HomeApi/Delete
        [HttpGet]
        public ActionResult Delete(long ID)
        {
           
            var del=db._studentDbModels.Where(x=>x.Id==ID).FirstOrDefault();
            if (ModelState.IsValid == true)
            {

                istudent.Delete(del.Id);
                TempData["DeleteMessage"] ="Data Deleted Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.DeleteMessage ="Data not deleted";
                return View();
            }
        }
    }
}