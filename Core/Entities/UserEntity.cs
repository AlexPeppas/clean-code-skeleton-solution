using GotSpaceSolution.Common;

namespace GotSpaceSolution.Core
{
    public sealed class UserEntity : BaseEntity
    {
        public string UserName { get; set; }

        public string Passsword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

    }
}
