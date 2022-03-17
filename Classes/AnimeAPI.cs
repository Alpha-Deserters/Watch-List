using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watch_List.Models;
using Watch_List.Models.Anime_API_models;

namespace Watch_List.Classes
{
    public class AnimeAPI
    {
        private string _uri = "https://api.jikan.moe/v4/";        

        public AnimeAPI()
        {

        }

        public async void GetAnimeList()
        {
            var endpoint = "anime";          
            try
            {
                var response = (await GetResponseAsync(endpoint))?["data"];
                
                foreach (var item in response)
                {
                    // ... mb in future
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }

        public async Task<Result<List<AnimeInformation>>> GetAnimeByName(string name)
        {
            var result = new Result<List<AnimeInformation>>
            {
                 Data = new List<AnimeInformation>()
            };
            
            var parameters = new Dictionary<string, string>()
            {
                {"q", name}
            };

            try
            {
                var response = (await GetResponseAsync(Endpoint.Anime, parameters))?["data"];

                foreach (var item in response)
                {
                    var info = new AnimeInformation();
                    var titleName = item?["title_english"];
                    var image = item?["images"]?["jpg"]?["image_url"];
                    //var url = item?["url"];                    
                    //var episodesCount = item?["episodes"];
                    result.Data.Add(info);
                }
            }
            catch (Exception error)
            {
                result.Error = error.Message;
            }

            return result;
        }

        public async Task<JToken?> GetResponseAsync(string endpoint, Dictionary<string, string>? parameters = null)
        {
            var body = GenerateParameters(parameters);
            var client = new RestClient(_uri + endpoint + body);
            var request = new RestRequest();// base request is GET           
            var response = (await client.ExecuteAsync(request)).Content;
            var deserelizeResponse = JsonConvert.DeserializeObject<JToken>(response);

            return deserelizeResponse;
        }
        
        private static string? GenerateParameters(Dictionary<string, string> postBody)
        {
            string? postData = null;

            if (postBody != null)
            {
                postData += '?';
                foreach (var item in postBody)
                {
                    postData += $"{item.Key}={item.Value}&";
                }
                
                postData.RemoveLastElement();
            }

            return postData;
        }       
    }
}
