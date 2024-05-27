using Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infrastructure.Data.EntityConfig
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(250);

            // Configura o relacionamento com a entidade Product
            builder.HasMany(m => m.Products)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Cascade);  // Defina o comportamento de exclusão, se necessário
        }
    }
}
