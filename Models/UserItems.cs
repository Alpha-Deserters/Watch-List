using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Watch_List.Classes;
using Watch_List.Interfaces;

namespace Watch_List.Models
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
