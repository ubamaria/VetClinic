using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VetClinicBusinessLogic.BindingModels;
using VetClinicBusinessLogic.Interfaces;
using VetClinicBusinessLogic.ViewModels;
using VetClinicDatabaseImplement.Models;

namespace VetClinicDatabaseImplement.Implements
{
    public class PetLogic : IPet
    {
        public void CreateOrUpdate(PetBindingModel model)
        {
            using (var context = new VetClinicDatabase())
            {
                Pet element = model.Id.HasValue ? null : new Pet();
                if (model.Id.HasValue)
                {
                    element = context.Pets.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Pet();
                    context.Pets.Add(element);
                }
                element.PetName = model.PetName;
                element.Kind = model.Kind;
                element.Breed = model.Breed;
                element.Age = model.Age;
                element.Gender = model.Gender;
                context.SaveChanges();
            }
        }
        public void Delete(PetBindingModel model)
        {
            using (var context = new VetClinicDatabase())
            {
                Pet element = context.Pets.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Pets.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<PetViewModel> Read(PetBindingModel model)
        {
            using (var context = new VetClinicDatabase())
            {
                return context.Pets
                 .Where(rec => model == null
                 || (rec.Id == model.Id && model.Id.HasValue))
            .Select(rec => new PetViewModel
            {
                Id = rec.Id,
                Kind = rec.Kind,
                PetName = rec.PetName,
                Breed = rec.Breed,
                Age = rec.Age,
                Gender = rec.Gender,
            })
                .ToList();
            }
        }
    }
}
