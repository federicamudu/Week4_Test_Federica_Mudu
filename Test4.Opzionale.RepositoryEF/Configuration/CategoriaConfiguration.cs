using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test4.Opzionale.Core.Entities;

namespace Test4.Opzionale.RepositoryEF.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorie");

            builder.Property(c => c.Id).IsRequired().UseIdentityColumn();
            builder.Property(s => s.Descrizione).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
        }
    }
}
