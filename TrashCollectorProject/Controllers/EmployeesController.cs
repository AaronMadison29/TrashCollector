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

                var customers = _repo.Customer.FindByCondition(x => x.Address.Zip == employee.Zip).ToList();

                List<Customer> dayCustomers = new List<Customer>();
                foreach (var customer in customers)
                {
                    if(_repo.Service.GetService(customer.ServiceId ?? default).PickupDay == DateTime.Now.DayOfWeek)
                    {
                        customer.Address = _repo.Address.GetAddress(customer.AddressId);
                        dayCustomers.Add(customer);
                    }
                }
                employeeViewModel.Customers = dayCustomers;
                return View(employeeViewModel);
            }
            else
            {
                return RedirectToAction("Create");
            }
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