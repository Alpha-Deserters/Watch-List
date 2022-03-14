using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_List.Tool_classes
{
    public static class AdditionalExtensions
    {
        /// <summary>
        /// Removes the last char element
        /// </summary>
        /// <param name="data">your string</param>
        public static void RemoveLastElement(this string data)
        {
            if(data.Length > 0)
            {
                //data = data.Substring(0, data.Length - 1);
                data = data.Remove(data.Length - 1, 1);
            }            
        }
    }
}
