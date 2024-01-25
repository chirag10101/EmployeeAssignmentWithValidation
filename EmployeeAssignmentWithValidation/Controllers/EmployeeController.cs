using EmployeeAssignmentWithValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAssignmentWithValidation.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> list = null;
        public EmployeeController()
        {
            if (list == null)
            {
                list = new List<Employee>()
            {
                    new() { Id =1, Name="Chirag", DateOfJoining=DateTime.Parse("20/10/2023"), Department="IT", Salary=50000 },

                    new() {  Id =2, Name="Saurav", DateOfJoining=DateTime.Parse("21/11/2023"), Department="HR", Salary=500000  },

                    new() {  Id =3, Name="Animesh", DateOfJoining=DateTime.Parse("03/05/2003"), Department="Sales", Salary=50000  }
            };
            }
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult Checkdate(DateTime DateOfJoining)
        {
            if (DateOfJoining <= DateTime.Now)
                return Json(data: true);
            else
                return Json(data: false);
        }

        public IActionResult Index()
        {
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if(ModelState.IsValid)
            {
                list.Add(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Display(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }
        }

        [HttpPost]
        public IActionResult Delete(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
                list.Remove(temp);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                ViewBag.msg = "Please provide a ID"; return View();
            }
            else
            {
                var employee = list.Where(x => x.Id == id).FirstOrDefault();
                if (employee == null)
                {
                    ViewBag.msg = "There is no record woth this ID";
                    return View();
                }
                else
                    return View(employee);
            }

        }

        [HttpPost]
        public IActionResult Edit(Employee employee, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Employee emp in list)
                {
                    if (emp.Id == employee.Id)
                    {
                        emp.Name = employee.Name;
                        emp.Salary = employee.Salary;
                        emp.DateOfJoining = employee.DateOfJoining;
                        emp.Department = employee.Department;
                        break;
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
} 