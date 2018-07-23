using CqrsCore2.App.Cqrs.Command.Models;
using CqrsCore2.App.Cqrs.Query.Queries;
using CqrsCore2.SharedKernel.Cqrs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CqrsCore2.Site.Controller
{
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IProcessor _processor;

        public CustomerController(IProcessor processor)
        {
            _processor = processor;
        }

        public IActionResult Index()
        {
            return View(_processor.Process(new GetCustomersIndex()));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCustomer customer)
        {
            _processor.Send(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            return View(_processor.Process(new GetCustomerDetails(id)));
        }

        public IActionResult Delete(Guid id)
        {
            _processor.Send(new DeleteCustomer(id));
            return RedirectToAction("Index");
        }
    }
}