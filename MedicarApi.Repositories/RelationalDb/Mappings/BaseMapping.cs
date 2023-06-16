using MedicarApi.Domain.Entities.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicarApi.Repositories.RelationalDb.Mappings
{
    public abstract class BaseMapping<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(z => z.Id);
        }
    }
}
