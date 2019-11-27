using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDDDCore.Domain.Entities;

namespace ProjetoDDDCore.Infra.Data.EntityConfig
{
    public class ClienteConfiguration: IEntityTypeConfiguration<Cliente>

    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.ClienteId).HasColumnName("CL_ID").ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).HasMaxLength(255).HasColumnName("CL_NOME").IsRequired();
            builder.Property(c => c.SobreNome).HasColumnName("CL_SOBRENOME").HasMaxLength(100);
            builder.Property(c => c.Email).HasColumnName("CL_EMAIL").HasMaxLength(50).IsRequired();
            builder.Property(c => c.DataCadastro).HasColumnName("CL_DATA_CADASTRO");
            builder.ToTable("TB_CLIENTES");
        }
    }
}
