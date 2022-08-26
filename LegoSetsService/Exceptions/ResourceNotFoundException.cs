namespace LegoSetsService.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException()
            : base("Resource not found")
        {
        }

        public ResourceNotFoundException(string resourceName)
            : base($"Resource {resourceName} not found")
        {
        }
    }
}
