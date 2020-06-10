using Microsoft.EntityFrameworkCore;
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
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pet element = model.Id.HasValue ? null : new Pet();
                        if (model.Id.HasValue)
                        {
                            element = context.Pets.FirstOrDefault(rec => rec.Id ==
                           model.Id && rec.PetName == model.PetName);
                            if (element == null)
                            {
                                throw new Exception("Такой питомец уже существует");
                            }
                            element.PetName = model.PetName;
                            element.Kind = model.Kind;
                            element.Breed = model.Breed;
                            element.Age = model.Age;
                            element.Gender = model.Gender;
                            element.ClientId = model.ClientId;
                            context.SaveChanges();
                        }
                        else
                        {
                            element.PetName = model.PetName;
                            element.Kind = model.Kind;
                            element.Breed = model.Breed;
                            element.Age = model.Age;
                            element.Gender = model.Gender;
                            element.ClientId = model.ClientId;
                        }
                        context.Pets.Add(element);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(PetBindingModel model)
        {
            using (var context = new VetClinicDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pet element = context.Pets.FirstOrDefault(rec => rec.Id == model.Id.Value);

                        if (element != null)
                        {
                            context.ClientPets.RemoveRange(
                                    context.ClientPets.Where(
                                        rec => rec.PetId == model.Id.Value));
                            context.Pets.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
            public List<PetViewModel> Read(PetBindingModel model)
            {
                using (var context = new VetClinicDatabase())
                {
                    return context.Pets
                     .Where(rec => model == null
                     || rec.Id == model.Id || rec.PetName == model.PetName)
                .Select(rec => new PetViewModel
                {
                    Id = rec.Id,
                    //ClientId = rec.ClientId,
                    Kind = rec.Kind,
                    PetName = rec.PetName,
                    Breed = rec.Breed,
                    Age = rec.Age,
                    Gender = rec.Gender,
                    ClientPets = GetClientPetViewModel(rec)
                })
                    .ToList();
                }
            }
            public static List<ClientPetViewModel> GetClientPetViewModel(Pet pet)
            {
                using (var context = new VetClinicDatabase())
                {
                    var ClientPets = context.ClientPets
                        .Where(rec => rec.PetId == pet.Id)
                        .Include(rec => rec.Client)
                        .Select(rec => new ClientPetViewModel
                        {
                            Id = rec.Id,
                            PetId = rec.PetId,
                            ClientId = rec.ClientId,
                            Count = rec.Count
                        }).ToList();
                    foreach (var client in ClientPets)
                    {
                        var clientData = context.Clients.Where(rec => rec.Id == client.ClientId).FirstOrDefault();
                        client.ClientFIO = clientData.ClientFIO;

                    }
                    return ClientPets;
                }
            }
        }
    }
