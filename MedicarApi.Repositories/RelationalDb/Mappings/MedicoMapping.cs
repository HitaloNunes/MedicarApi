using MedicarApi.Domain.Entities.DB;
using MedicarApi.Domain.Entities.NoSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicarApi.Repositories.RelationalDb.Mappings
{
    public class MedicoMapping : BaseMapping<Medico>
    {
        public override void Configure(EntityTypeBuilder<Medico> builder)
        {
            base.Configure(builder);

            builder.Property(z => z.Nome)
                .IsRequired()
                .HasColumnType("varchar(MAX)");

            builder.Property(z => z.CRM)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(z => z.Email)
                .IsRequired()
                .HasColumnType("varchar(MAX)");

            builder.HasMany(z => z.Disponibilidade)
                .WithOne(x => x.Medico)
                .HasForeignKey(x => x.IdMedico)
                .IsRequired();
        }
    }
}
