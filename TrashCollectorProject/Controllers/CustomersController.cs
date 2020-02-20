﻿using System;
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
                viewModel.Service = _repo.Service.GetService(user.ServiceId ?? default);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult BeginService()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BeginService(Service service)
        {
            service.isActive = true;
            _repo.Service.CreateService(service);
            _repo.Save();

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _repo.Customer.GetCustomer(userId);

            user.ServiceId = service.Id;
            _repo.Customer.Update(user);

            _repo.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewModel viewModel = new ViewModel();
            var user = _repo.Customer.GetCustomer(userId);
            viewModel.Customer = user;
            viewModel.Address = _repo.Address.GetAddress(user.AddressId);
            viewModel.IdentityUser = _repo.Customer.GetIdentityUser(user.IdentityId);
            viewModel.Service = _repo.Service.GetService(user.ServiceId ?? default);
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

        public ActionResult EditPickupDay()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _repo.Customer.GetCustomer(userId);

            var service = _repo.Service.GetService(user.ServiceId ?? default);

            return View(service);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPickupDay(Service service)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _repo.Customer.GetCustomer(userId);

                var serviceToChange = _repo.Service.GetService(user.ServiceId ?? default);
                serviceToChange.PickupDay = service.PickupDay;

                _repo.Service.Update(serviceToChange);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult EditAddress()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _repo.Customer.GetCustomer(userId);

            Address address = _repo.Address.GetAddress(user.AddressId);

            return View(address);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddress(Address address)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _repo.Customer.GetCustomer(userId);

                var addressToChange = _repo.Address.FindByCondition(x => x.Id == user.AddressId).First();
                addressToChange.StreetAddress = address.StreetAddress;
                addressToChange.City = address.City;
                addressToChange.State = address.State;
                addressToChange.Zip = address.Zip;

                _repo.Address.Update(addressToChange);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SetupOTP()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetupOTP(Service service)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _repo.Customer.GetCustomer(userId);

                if(_repo.Service.GetService(user.ServiceId ?? default) is null)
                {
                    _repo.Service.CreateService(service);

                    user.ServiceId = service.Id;

                }
                else
                {
                    var serviceToChange = _repo.Service.GetService(user.ServiceId ?? default);
                    serviceToChange.OneTimePickup = service.OneTimePickup;

                    _repo.Service.Update(serviceToChange);
                }

                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Billing()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _repo.Customer.GetCustomer(userId);

            var service = _repo.Service.GetService(user.ServiceId ?? default);

            return View(service);
        }
    }
}