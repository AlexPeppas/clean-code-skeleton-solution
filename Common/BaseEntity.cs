
namespace GotSpaceSolution.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsDeleted { get; set; }
    }
}
