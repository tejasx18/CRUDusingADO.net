using CRUDusingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingADO.Controllers
{
    public class StudentController : Controller
    {

        private readonly IConfiguration configuration;
        StudentCRUD db;

        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new StudentCRUD(this.configuration);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var response = db.GetStudents();
            return View(response);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var res = db.GetStudentById(id);
            return View(res);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            try
            {
                int response = db.AddStudent(std);
                if (response >= 1)
               
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = db.GetStudentById(id);
            return View(res);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student std)
        {
            try
            {
                int response = db.UpdateStudent(std);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = db.GetStudentById(id);
            return View(res);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int response = db.DeleteStudent(id);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
