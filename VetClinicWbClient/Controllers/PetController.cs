using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.Interfaces;
using VetClinicBusinessLogic.ViewModels;
using VetClinicDatabaseImplement;
using VetClinicWbClient.Models;

namespace VetClinicWbClient.Controllers
{
    public class PetController : Controller
    {
        private readonly IPet _pet;
        public PetController(IPet pet)
        {
            _pet = pet;
        }
        public IActionResult Pet()
        {
            ViewBag.Pets = _pet.Read(new PetBindingModel
            {
                ClientId = Program.Client.Id
            });
            return View();
        }
        public ActionResult ProfilePet()
        {
            ViewBag.Pets = _pet.Read(null);
            return View();

        }
        [HttpPost]
        public ActionResult Pet(PetModel pet)
        {
            if (!ModelState.IsValid)
                {
                    ViewBag.ClientPets = _pet.Read(null);
                    return View(pet);
                }
            _pet.CreateOrUpdate(new PetBindingModel
                {
                    ClientId = Program.Client.Id,
                    PetName = pet.PetName,
                    Kind = pet.Kind,
                    Breed = pet.Breed,
                    Age = pet.Age,
                    Gender = pet.Gender
                });
                ModelState.AddModelError("", "Вы успешно добавили питомца");
               return RedirectToAction("ProfilePet");
        }
    }
}



