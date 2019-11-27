using Microsoft.EntityFrameworkCore;
using ProjetoDDDCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjetoDDDCore.Infra.Data.EntityConfig;

namespace ProjetoDDDCore.Infra.Data.Context
{
    public class ProjetoContext: DbContext 
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options): base(options) { }


        public virtual DbSet<Cliente> Clientes { get; set; }
        public  DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property<string>(e => e.Nome).HasColumnType("VARCHAR").HasMaxLength(250);
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {

                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
            return base.SaveChanges();
        }

    }
}
