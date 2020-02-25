using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using TrashCollectorProject.Contracts;
using TrashCollectorProject.Models;
using Service = TrashCollectorProject.Models.Service;
using Customer = TrashCollectorProject.Models.Customer;
using Address = TrashCollectorProject.Models.Address;


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
                CustomerViewModel viewModel = new CustomerViewModel();
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
            CustomerViewModel viewModel = new CustomerViewModel();
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

        public ActionResult SuspendService()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _repo.Customer.GetCustomer(userId);

            var service = _repo.Service.GetService(user.ServiceId ?? default);

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuspendService(Service service)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _repo.Customer.GetCustomer(userId);

                var serviceToChange = _repo.Service.GetService(user.ServiceId ?? default);
                serviceToChange.SuspensionStart = service.SuspensionStart;
                serviceToChange.SuspensionEnd = service.SuspensionEnd;

                _repo.Service.Update(serviceToChange);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Charge(string stripeEmail, string stripeToken, int serviceId)
        {
            try
            {
                var customers = new CustomerService();
                var charges = new ChargeService();

                var service = _repo.Service.FindByCondition(x => x.Id == serviceId).FirstOrDefault();

                var customer = customers.Create(new CustomerCreateOptions
                {
                    Email = stripeEmail,
                    Source = stripeToken
                });

                var charge = charges.Create(new ChargeCreateOptions
                {
                    Amount = (long)service.Balance * 100,//charge in cents
                    Description = "Waste Pickup",
                    Currency = "usd",
                    Customer = customer.Id
                });

                

                service.Balance = 0;
                _repo.Service.Update(service);
                _repo.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Billing");
            }
        }

    }
}