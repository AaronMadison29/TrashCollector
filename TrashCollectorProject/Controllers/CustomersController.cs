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
    public class CustomersController : Controller
    {
        private readonly IRepositoryWrapper _repo;

        public CustomersController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (_repo.Customer.FindByCondition(x => x.IdentityId == userId).Any())
            {
                ViewModel viewModel = new ViewModel();
                var user = _repo.Customer.GetCustomer(userId);
                viewModel.Customer = user;
                viewModel.Address = _repo.Address.GetAddress(user.AddressId);
                viewModel.IdentityUser = _repo.Customer.GetIdentityUser(user.IdentityId);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult SetDeliveryDay()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _repo.Customer.FindByCondition((x => x.IdentityUser.Id == userId));
            return View(user);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewModel viewModel = new ViewModel();
            var user = _repo.Customer.GetCustomer(userId);
            viewModel.Customer = user;
            viewModel.Address = _repo.Address.GetAddress(user.AddressId);
            viewModel.IdentityUser = _repo.Customer.GetIdentityUser(user.IdentityId);
            return View(viewModel);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Address")]Customer customer)
        {
            try
            {

                Customer newCustomer = new Customer();

                _repo.Address.CreateAddress(customer.Address);
                _repo.Save();


                newCustomer.Name = customer.Name;
                newCustomer.IdentityId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                newCustomer.AddressId = _repo.Address.FindByCondition(x => x.Equals(customer.Address)).First().Id;

                _repo.Customer.CreateCustomer(newCustomer);

                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}