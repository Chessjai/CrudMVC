using CrudMVC.Models;
using CrudMVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVC.Controllers
{
    public class StudentController : Controller
    {
        private StudentServices GetStudentServices;

        public ActionResult List()
        {
            GetStudentServices = new StudentServices();
            var model=GetStudentServices.GetStudentsList();
            return View(model);
        }

        public ActionResult AddStudent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(StudentModel model)
        {

            GetStudentServices = new StudentServices();
            GetStudentServices.InsertStudent(model);
            return RedirectToAction("List");
        }

        public ActionResult EditStudent(int Id) 
        {

            GetStudentServices = new StudentServices();
            var model=GetStudentServices.GetEditByid(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditStudent(StudentModel model)
        {

            GetStudentServices = new StudentServices();
            GetStudentServices.UpdateStudent(model);
            return RedirectToAction("List");
        }

        public ActionResult DeleteStudent(int Id)
        {

            GetStudentServices = new StudentServices();
            GetStudentServices.DeleteStudent(Id);

            return RedirectToAction("List");
        }
    }
}