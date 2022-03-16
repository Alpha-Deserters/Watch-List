using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Watch_List.Model_classes
{
    public class User
    {
        public User()
        {

        }

        public User(string login, string password, string email)
        {
            (Login, Password, Email) = (login, password, email);
        }

        [JsonPropertyName("login")]
        public string? Login { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
