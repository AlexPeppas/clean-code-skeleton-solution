using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contracts
{
    [JsonObject]
    public sealed class CreateUser
    {
        [JsonProperty(PropertyName = "userName", Required = Required.Always)]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "passsword", Required = Required.Always)]
        public string Passsword { get; set; }

        [JsonProperty(PropertyName = "firstName", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "emailAddress", Required = Required.Always)]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "phoneNumber", Required = Required.Always)]
        public string PhoneNumber { get; set; }
    }
}
