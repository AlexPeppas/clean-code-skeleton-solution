namespace GotSpace.Infrastructure
{
    public sealed class EntityIdentifierException : Exception
    {
        private const string ErrorMessage = $"Entities require an Identifier";

        public EntityIdentifierException(string entityName)
            : base(ErrorMessage)
        {
            EntityName = entityName;
        }

        public string EntityName { get; set; }
    }
}
