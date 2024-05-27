using Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infrastructure.Data.EntityConfig
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Configura a chave primária
            builder.HasKey(m => m.Id);

            // Configura a propriedade Name
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Configura a propriedade Value
            builder.Property(m => m.Value)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Especifica o tipo de dado para o banco de dados

            // Configura a propriedade Ative
            builder.Property(m => m.Ative)
                .IsRequired();

            // Configura o relacionamento com a entidade Category
            builder.HasOne(m => m.Category)
                .WithMany()
                .HasForeignKey(m => m.IdCategory);

            // Configura o relacionamento com a entidade Client
            builder.HasOne(m => m.Client)
                .WithMany(c => c.Products)
                .HasForeignKey(m => m.IdClient)
                .OnDelete(DeleteBehavior.Restrict);  // Defina o comportamento de exclusão, se necessário

        }
    }
}
