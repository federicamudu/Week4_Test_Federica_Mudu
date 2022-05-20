using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;
using Test4.Opzionale.RepositoryEF.Configuration;

namespace Test4.Opzionale.RepositoryEF
{
    public class MasterContext:DbContext
    {
        public DbSet<Spesa> Spese { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public MasterContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpeseEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Spesa>(new SpesaConfiguration());
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaConfiguration());

        }
    }
}
