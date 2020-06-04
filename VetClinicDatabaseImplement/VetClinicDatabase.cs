using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VetClinicDatabaseImplement.Models;

namespace VetClinicDatabaseImplement
{
    public class VetClinicDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-BUNOAQN\SQLEXPRESS;
                                            Initial Catalog=FoodOrderDatabase;
                                            Integrated Security=True;
                                            MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Service> Services { set; get; }
        public virtual DbSet<Reception> Receptions { set; get; }
        public virtual DbSet<ReceptionService> ReceptionServices { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Pet> Pets { set; get; }
        public virtual DbSet<ClientPet> ClientPets { set; get; }
        public virtual DbSet<Payment> Payments { set; get; }
    }
}
