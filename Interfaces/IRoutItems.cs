using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Watch_List.Models;

namespace Watch_List.Interfaces
{
    public interface IRoutItems<T>
    {
        public List<T> Items { get; set; }
    }
}
