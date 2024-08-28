using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;
public class ControleGlicemicoMapping : IEntityTypeConfiguration<ControleGlicemico>
{
    public void Configure(EntityTypeBuilder<ControleGlicemico> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Data)
            .IsRequired();

        builder.Property(x => x.ValorGlicemico)
            .IsRequired();
    }
}