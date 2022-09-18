namespace GotSpace.Infrastructure
{
    public sealed class EntityNotFoundException : Exception
    {
        private const string ErrorMessage = "Entity not found";

        public EntityNotFoundException(Guid id)
            : base(ErrorMessage)
        {
            EntityId = id;
        }

        public Guid EntityId { get; set; }
    }
}
