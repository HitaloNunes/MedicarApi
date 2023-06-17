namespace MedicarApi.Domain.Entities.DB
{
    public abstract class Entity
    {
        protected Entity()
        {

        }

        public int Id { get; set; }
    }
}
