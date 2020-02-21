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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (_repo.Employee.FindByCondition(x => x.IdentityId == userId).Any())
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel();

                var employee = _repo.Employee.GetEmployee(userId);

                employeeViewModel.Employee = employee;

                var customers = _repo.Customer.GetCustomersIncludeAll(); //List of customers

                customers = GetTodaysCustomers(customers, employee.Zip);

                employeeViewModel.Customers = customers;

                return View(employeeViewModel);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult CustomerDatabase()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _repo.Employee.GetEmployee(userId);

            employeeViewModel.Employee = employee;
            employeeViewModel.Customers = _repo.Customer.GetCustomersIncludeAll();

            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerDatabase(EmployeeViewModel viewModelIn)
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _repo.Employee.GetEmployee(userId);

            employeeViewModel.Employee = employee;
            employeeViewModel.Customers = _repo.Customer.GetCustomersIncludeAll().Where(c => c.Service.PickupDay == viewModelIn.QueryDay).ToList();
            employeeViewModel.QueryDay = viewModelIn.QueryDay;

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

        public List<Customer> GetTodaysCustomers(List<Customer> customers, int employeeZip)
        {
            return customers.Where(c => c.Address.Zip == employeeZip && c.Service.isActive is true && c.Service.PickupDay == DateTime.Now.DayOfWeek).ToList();
        }
    }
}