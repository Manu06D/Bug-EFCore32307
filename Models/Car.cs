namespace Models
{
    public class Car : IEntity
    {
        public Guid Id { get; set; }

        public string? ETag { get; set; }

        public string? Name { get; set; }
        public List<Guid> Properties {  get; set; }
    }
}
