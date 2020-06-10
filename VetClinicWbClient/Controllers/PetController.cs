using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.Interfaces;
using VetClinicWbClient.Models;

namespace VetClinicWbClient.Controllers
{
    public class PetController : Controller
    {
        private readonly IPet _pet;
        private readonly IClient _client;
        public PetController(IPet pet, IClient client)
        {
            _client = client;
            _pet = pet;
        }
        public IActionResult Pet()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Pet(PetModel pet)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ClientPets = _pet.Read(null);
                return View(pet);
            }
            if (pet.ClientPets == null)
            {
                ViewBag.ClientPets = _pet.Read(null);
                ModelState.AddModelError("", "Питомец не добавлен");
                return View(pet);
            }
            var clientPets = new List<ClientPetBindingModel>();
            foreach (var p in pet.ClientPets)
            {
                if (p.Value > 0)
                {
                    clientPets.Add(new ClientPetBindingModel
                    {
                        PetId = p.Key,
                        Count = p.Value
                    });
                }
            }
            _pet.CreateOrUpdate(new PetBindingModel
                {
                    //ClientId = Program.Client.Id,
                    PetName = pet.PetName,
                    Kind = pet.Kind,
                    Breed = pet.Breed,
                    Age = pet.Age,
                    Gender = pet.Gender,
                    ClientPets = clientPets
                });
                ModelState.AddModelError("", "Вы успешно добавили питомца");
                return View(pet);
        }
    }
}