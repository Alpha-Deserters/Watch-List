using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Watch_List.Model_classes;

namespace Watch_List.Tool_classes
{
    public interface IRoutItems<T>
    {
        public List<T> Items { get; set; }
    }
}
