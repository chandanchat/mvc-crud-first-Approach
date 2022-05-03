using mvc_crud_first_Approach.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_crud_first_Approach.Controllers
{
    public class StudentController : Controller
    {
        tp_7Entities dbobj = new tp_7Entities();
        // GET: Student
        public ActionResult student(student obj)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Addstudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addstudent(student model)
        {           
                student obj = new student();
                obj.name = model.name;
                obj.rollno = model.rollno;
                obj.age = model.age;
                obj.city = model.city;
                dbobj.students.Add(obj);
                dbobj.SaveChanges();
            return View("student");


        }
        
        public ActionResult studentList()
        {
            var res = dbobj.students.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbobj.students.Where(x => x.id==id).FirstOrDefault();
            dbobj.students.Remove(res);
            dbobj.SaveChanges();
            var list= dbobj.students.ToList();
            return View("studentList",list);
        }
    }

}