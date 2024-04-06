using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Vjezba26032024.Models;
using Vjezba26032024.Models.Binding;
using Vjezba26032024.Models.Dbo;
using Vjezba26032024.Services.Interfaces;

namespace Vjezba26032024.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService invoiceService;
        private readonly IMapper mapper;

        public InvoiceController(IInvoiceService invoiceServicer, IMapper mapper)
        {
            this.invoiceService = invoiceServicer;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var response = invoiceService.GetInvoices();
            return View(response);
        }

        public IActionResult CreateInvoiceItem(int invoiceId)
        {
            var response = new InvoiceItemBinding { InvoiceId = invoiceId };
            return View(response);
        }

        [HttpPost]
        public IActionResult CreateInvoiceItem(InvoiceItemBinding model)
        {
            invoiceService.AddInvoiceItem(model);

            return RedirectToAction("Details", new { id = model.InvoiceId });
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(InvoiceBinding model)
        {
            invoiceService.AddInvoice(model);
            return RedirectToAction("Index");
        }



        public IActionResult Delete(int id)
        {
            invoiceService.DeleteInvoice(id);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteInvoiceItem(int id, int invoiceId)
        {
            invoiceService.DeleteInvoiceItem(id, invoiceId);
            return RedirectToAction("Details", new { id = invoiceId });
        }

        public IActionResult Edit(int id)
        {
            var oldInvoice = invoiceService.GetInvoice(id);
            var response = mapper.Map<InvoiceUpdateBinding>(oldInvoice);
            return View(response);
        }


        public IActionResult EditInvoiceItem(int id,int invoiceId)
        {
            var oldInvoiceItem = invoiceService.GetInvoiceItem(id, invoiceId);
            var response = mapper.Map<InvoiceItemUpdateBinding>(oldInvoiceItem);
            return View(response);
        }

        [HttpPost]
        public IActionResult EditInvoiceItem(InvoiceItemUpdateBinding model)
        {
            invoiceService.UpdateInvoiceItem(model);
            return RedirectToAction("Details", new { id = model.InvoiceId });
        }


        [HttpPost]
        public IActionResult Edit(InvoiceUpdateBinding model)
        {
            invoiceService.UpdateInvoice(model);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var response = invoiceService.GetInvoice(id);
            return View(response);
        }

        public IActionResult InvoiceItemDetails(int id, int invoiceId)
        {
            var response = invoiceService.GetInvoiceItem(id, invoiceId);
            return View(response);
        }

    }
}
