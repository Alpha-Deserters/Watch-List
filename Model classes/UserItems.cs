using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Watch_List.Tool_classes;

namespace Watch_List.Model_classes
{
    public class UserItems : IRoutItems<User>
    {
        [JsonPropertyName("items")]
        public List<User>? Items { get; set; }

        public async Task UpdateItems()
        {
            Items = new List<User>();
            await this.ConvertJsonToList("Users");
        }
    }
}
