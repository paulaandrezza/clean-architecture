namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public string EntityName { get; }
        public object EntityId { get; }

        public NotFoundException(string entityName, object entityId)
            : base($"The {entityName} with ID {entityId} could not be found.")
        {
            EntityName = entityName;
            EntityId = entityId;
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
