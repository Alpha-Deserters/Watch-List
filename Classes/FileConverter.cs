using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;
using Watch_List.Models;
using System.Windows;
using Watch_List.Interfaces;

namespace Watch_List.Classes
{
    public static class FileConverter
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true};

        public static async Task ConvertJsonToList<TSource>(this IRoutItems<TSource> list, string fileName)
            where TSource : class
        {
            FileStream? fs = null;

            try
            {              
                fs = new FileStream($"{LocalPath.JsonPath}{fileName}.json", FileMode.Open);
                var jsonItems = await System.Text.Json.JsonSerializer.DeserializeAsync(fs, list.GetType());
                
                foreach (var item in ((IRoutItems<TSource>?)jsonItems)?.Items)
                {
                    list.Items.Add(item);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            finally
            {
                await fs.DisposeAsync();
            }
        }

        public static async Task<Result<bool>> TryWriteToJson<T>(T instance, string fileName)
            where T : class
        {
            var result = new Result<bool>();
            FileStream? fs = null;

            try
            {               
                fs = new FileStream($"{LocalPath.JsonPath}{fileName}.json", FileMode.Create);                
                await System.Text.Json.JsonSerializer.SerializeAsync<T>(fs, instance, _jsonSerializerOptions);                
                result.Data = true;                
            }
            catch (Exception error)
            {
                result.Data = false;
                result.Error = error.Message;
            }
            finally
            {
                await fs.DisposeAsync();
            }

            return result;
        }
    }
}
