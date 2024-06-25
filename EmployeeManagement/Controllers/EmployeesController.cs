using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeesController : Controller
    {
        //Dependency Injection
        private readonly IEmployeeRepository _repository;
        public EmployeesController(IEmployeeRepository repository)
        {
            _repository=repository;
        }
        // GET: EmployeesController
        public ActionResult Index()
        {
           var employees= _repository.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            ViewBag.departments = _repository.GetAllDepartments();
            ViewBag.types = _repository.GetEmployeementTypes();
            ViewBag.genders = _repository.GetAllGender();
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                ViewBag.departments = _repository.GetAllDepartments();
                ViewBag.types = _repository.GetEmployeementTypes();
                ViewBag.genders = _repository.GetAllGender();
                if (ModelState.IsValid)
                {
                    _repository.InsertEmployee(employee); 
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.departments = _repository.GetAllDepartments();
            ViewBag.types = _repository.GetEmployeementTypes();
            ViewBag.genders = _repository.GetAllGender();

            //Search by is and employee data
           Employee employee = _repository.GetEmployeeById(id);

            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                ViewBag.departments = _repository.GetAllDepartments();
                ViewBag.types = _repository.GetEmployeementTypes();
                ViewBag.genders = _repository.GetAllGender();
                if (ModelState.IsValid)
                {
                    _repository.UpdateEmployee(id, employee);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = _repository.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                _repository.DeleteEmployee((int)id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
