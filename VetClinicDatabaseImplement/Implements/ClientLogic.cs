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
    public class ClientLogic : IClient
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new VetClinicDatabase())
            {
                Client element = model.Id.HasValue ? null : new Client();
                if (model.Id.HasValue)
                {
                    element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Client();
                    context.Clients.Add(element);
                }
                element.ClientFIO = model.ClientFIO;
                element.Email = model.Email;
                element.Login = model.Login;
                element.Phone = model.Phone;
                element.Block = model.Block;
                element.Password = model.Password;
                context.SaveChanges();
            }
        }
        public void Delete(ClientBindingModel model)
        {
            using (var context = new VetClinicDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new VetClinicDatabase())
            {
                return context.Clients
                 .Where(rec => model == null
                 || rec.Id == model.Id
                 || (rec.Login == model.Login || rec.Email == model.Email)
                 && (model.Password == null || rec.Password == model.Password))
            .Select(rec => new ClientViewModel
               {
                   Id = rec.Id,
                   Login = rec.Login,
                   ClientFIO = rec.ClientFIO,
                   Email = rec.Email,
                   Password = rec.Password,
                   Phone = rec.Phone,
                   Block = rec.Block
               })
                .ToList();
            }
        }
    }
}
