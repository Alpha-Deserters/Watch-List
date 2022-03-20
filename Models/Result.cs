using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_List.Models
{
    public class Result<T>        
    {
        public T? Data { get; set; }
        public string? Error { get; set; }
    }
}
