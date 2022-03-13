using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_List.Model_classes
{
    public class User
    {
        [JsonProperty("login")]
        public string? Login { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

    }
}
