using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.Enums;
using VetClinicBusinessLogic.Interfaces;
using VetClinicBusinessLogic.ViewModels;
using VetClinicWbClient.Models;


namespace VetClinicWbClient.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly IReception _reception;
        private readonly IService _service;
        private readonly IPayment _payment;
        public ReceptionController(IReception reception, IService service, IPayment payment)
        {
            _reception = reception;
            _service = service;
            _payment = payment;
        }
        public IActionResult Reception()
        {
            ViewBag.Receptions = _reception.Read(new ReceptionBindingModel
            {
                ClientId = Program.Client.Id
            });
            return View();
        }
        public IActionResult CreateReception()
        {
            ViewBag.ReceptionServices = _service.Read(null);
            return View();
        }
        [HttpPost]
        public ActionResult CreateReception(CreateReceptionModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ReceptionServices = _service.Read(null);
                return View(model);
            }

            if (model.ReceptionServices == null)
            {
                ViewBag.ReceptionServices = _service.Read(null);
                ModelState.AddModelError("", "Ни одна услуга не выбрана");
                return View(model);
            }
            var receptionServices = new List<ReceptionServiceBindingModel>();

            foreach (var service in model.ReceptionServices)
            {
                if (service.Value > 0)
                {
                    receptionServices.Add(new ReceptionServiceBindingModel
                    {
                        ServiceId = service.Key,
                        Count = service.Value
                    });
                }
            }
            if (receptionServices.Count == 0)
            {
                ViewBag.Products = _service.Read(null);
                ModelState.AddModelError("", "Ни одна услуга не выбрана");
                return View(model);
            }
            _reception.CreateOrUpdate(new ReceptionBindingModel
            {
                ClientId = Program.Client.Id,
                DateCreate = DateTime.Now,
                ReceptionStatus = ReceptionStatus.Оформлен,
                TotalSum = CalculateSum(receptionServices),
                ReceptionServices = receptionServices
            });
            return RedirectToAction("Reception");
        }
        private int CalculateSum(List<ReceptionServiceBindingModel> receptionServices)
        {
            int sum = 0;
            foreach (var service in receptionServices)
            {
                var serviceData = _service.Read(new ServiceBindingModel { Id = service.ServiceId }).FirstOrDefault();

                if (serviceData != null)
                {
                    for (int i = 0; i < service.Count; i++)
                        sum += serviceData.Price;
                }
            }
            return sum;
        }
        private int CalculateLeftSum(ReceptionViewModel reception)
        {
            int sum = reception.TotalSum;
            int paidSum = _payment.Read(new PaymentBindingModel
            {
                ReceptionId = reception.Id
            }).Select(rec => rec.Sum).Sum();

            return sum - paidSum;
        }
        public IActionResult Payment(int id)
        {
            var reception = _reception.Read(new ReceptionBindingModel
            {
                Id = id
            }).FirstOrDefault();
            ViewBag.Reception = reception;
            ViewBag.LeftSum = CalculateLeftSum(reception);
            return View();
        }
        [HttpPost]
        public ActionResult Payment(PaymentModel model)
        {
            ReceptionViewModel reception = _reception.Read(new ReceptionBindingModel
            {
                Id = model.ReceptionId
            }).FirstOrDefault();
            int leftSum = CalculateLeftSum(reception);
            if (!ModelState.IsValid)
            {
                ViewBag.Travel = reception;
                ViewBag.LeftSum = leftSum;
                return View(model);
            }
            if (leftSum < model.Sum)
            {
                ViewBag.Reception = reception;
                ViewBag.LeftSum = leftSum;
                return View(model);
            }
            _payment.CreateOrUpdate(new PaymentBindingModel
            {
                ReceptionId = reception.Id,
                ClientId = Program.Client.Id,
                DatePayment = DateTime.Now,
                Sum = model.Sum
            });
            leftSum -= model.Sum;
            _reception.CreateOrUpdate(new ReceptionBindingModel
            {
                Id = reception.Id,
                ClientId = reception.ClientId,
                DateCreate = reception.DateCreate,
                ReceptionStatus = leftSum > 0 ? ReceptionStatus.ОплаченЧастично : ReceptionStatus.Оплачен,
                TotalSum = reception.TotalSum,
                ReceptionServices = reception.ReceptionServices.Select(rec => new ReceptionServiceBindingModel
                {
                    Id = rec.Id,
                    ReceptionId = rec.ReceptionId,
                    ServiceId = rec.ServiceId,
                    Count = rec.Count
                }).ToList()
            });
            return RedirectToAction("Reception");
        }
    }
}