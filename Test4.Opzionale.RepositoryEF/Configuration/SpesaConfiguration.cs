
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
    public class SpesaConfiguration : IEntityTypeConfiguration<Spesa>
    {
        public void Configure(EntityTypeBuilder<Spesa> builder)
        {
            builder.ToTable("Spese");

            builder.Property(s => s.Id).IsRequired().UseIdentityColumn();
            builder.Property(s => s.DataSpesa).HasColumnType("datetime").IsRequired();          
            builder.Property(s => s.Descrizione).HasColumnType("nvarchar").HasMaxLength(500).IsRequired();
            builder.Property(s => s.Utente).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(s => s.Importo).HasColumnType("decimal").HasMaxLength(100);
            builder.Property(s => s.Approvato).HasColumnType("bit").HasDefaultValue(0).IsRequired();
            builder.Property(s => s.Id).HasColumnType("int").IsRequired();
        }
    }
}
