using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_List.Tool_classes
{
    public static class FileConverter
    {
        private static readonly string _path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\"));

        public static void ConvertJsonToList<TSource>(this List<TSource> list, string fileName)
        {
            try
            {
                var json = File.ReadAllText($"{_path}JSON\\{fileName}.json");
                var jsonItems = (JsonConvert.DeserializeObject<JToken>(json)?["items"])?.ToString();   
                if(jsonItems != null)
                {
                    var jsonList = JsonConvert.DeserializeObject<List<TSource>>(jsonItems);
                    foreach (var item in jsonList)
                    {
                        list.Add(item);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }                                  
        }
    }
}
