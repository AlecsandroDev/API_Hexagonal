namespace API_Hexagonal.Entities
{
    public class EntitiyBase
    {
        public Guid Id { get; set; }

        public EntitiyBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
