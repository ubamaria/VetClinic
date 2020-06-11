using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.Interfaces;
using VetClinicDatabaseImplement;
using VetClinicWbClient.Models;

namespace VetClinicWbClient.Controllers
{
    public class PetController : Controller
    {
        private readonly IPet _pet;
        private readonly IClient _client;
        public IPet Service = Globals.Pet;
        public PetController(IPet pet, IClient client)
        {
            _client = client;
            _pet = pet;
        }
        public IActionResult Pet()
        {
            return View();
        }
        public ActionResult ProfilePet()
        {
            ViewBag.Pets = _pet.GetList();
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



