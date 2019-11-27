using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>

    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.UsuarioId).HasColumnName("U_ID").ValueGeneratedOnAdd();
            builder.Property(u => u.Nome).HasColumnName("U_NOME").HasMaxLength(100).IsRequired();
            builder.Property(u=>u.Senha).HasColumnName("U_SENHA").HasMaxLength(100).IsRequired();
            builder.ToTable("TB_USUARIOS");
        }
    }
}
