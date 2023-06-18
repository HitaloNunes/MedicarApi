using MedicarApi.Domain.Entities.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicarApi.Repositories.RelationalDb.Mappings
{
    public class DisponibilidadeMapping : BaseMapping<Disponibilidade>
    {
        public override void Configure(EntityTypeBuilder<Disponibilidade> builder)
        {
            base.Configure(builder);

            builder.Property(z => z.IdMedico)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(z => z.Disponivel)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("bit");

            builder.Property(z => z.Dia)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(z => z.Horario)
                .IsRequired()
                .HasColumnType("time");

            builder.HasOne<Medico>(z => z.Medico)
                .WithMany(x => x.Disponibilidade)
                .HasForeignKey(z => z.IdMedico);
        }
    }
}
