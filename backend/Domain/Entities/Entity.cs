namespace SmartPark.Domain.Entities
{
    public abstract class Entity<TKey>
    {
        public TKey? Id { get; set; }
        public bool Deleted { get; set; }
    }
}
