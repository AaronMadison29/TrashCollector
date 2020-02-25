using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrashCollectorProject.Contracts;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryWrapper _repo;

        public HomeController(UserManager<IdentityUser> userManager, ILogger<HomeController> logger, IRepositoryWrapper repo)
        {
            _userManager = userManager;
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            try
            {
                CustomerUpdate();
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    var user = _userManager.FindByIdAsync(userId).Result;
                    var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
                    if (role == "Customer")
                    {
                        return RedirectToAction("Index", "Customers");
                    }
                    else if (role == "Employee")
                    {
                        return RedirectToAction("Index", "Employees");
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public void CustomerUpdate()
        {
            var customers = _repo.Customer.GetCustomersIncludeAll();

            foreach (var customer in customers)
            {
                if(DateTime.Now.Date > customer.Service.SuspensionEnd)
                {
                    customer.Service.SuspensionStart = null;
                    customer.Service.SuspensionEnd = null;
                }
                if (customer.Service.SuspensionStart <= DateTime.Now.Date && DateTime.Now.Date <= customer.Service.SuspensionEnd)
                {
                    customer.Service.isActive = false;
                }
                else
                {
                    customer.Service.isActive = true;
                }
                if (DayOfWeek.Sunday == DateTime.Now.DayOfWeek)
                {
                    customer.Service.PickedUp = false;
                }
                _repo.Customer.Update(customer);
                _repo.Save();
            }
        }
    }
}
