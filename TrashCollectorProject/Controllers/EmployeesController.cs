using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollectorProject.Contracts;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        public EmployeesController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            employeeViewModel.Employee = _repo.Employee.GetEmployee(userId);

            employeeViewModel.Customers = _repo.Customer.FindAll().ToList();

            return View(employeeViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {

                Employee newEmployee = new Employee();



                newEmployee.Name = employee.Name;
                newEmployee.IdentityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                newEmployee.Zip = employee.Zip;


                _repo.Employee.CreateEmployee(newEmployee);

                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}