using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watch_List.Tool_classes
{
    public class AnimeAPI
    {
        private string _uri = "https://api.jikan.moe/v4/";
        private string _apiKey = "";

        public AnimeAPI()
        {

        }

        public async void GetAnimeList()
        {
            var endpoint = "anime";
            var parameters = new Dictionary<string, string>()
            {
                {"q", "Attack on Titan"}
            };
            try
            {
                var response = await GetResponseAsync(endpoint, parameters);
                var deserelizeResponse = JsonConvert.DeserializeObject<JToken>(response)?["data"];
                foreach (var item in deserelizeResponse)
                {
                    
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public async void GetAnimeByName()
        {
            try
            {

            }
            catch (Exception error)
            {

            }
        }

        public async Task<string> GetResponseAsync(string endpoint, Dictionary<string, string> parameters)
        {
            var client = new RestClient(_uri + endpoint + GenerateParameters(parameters));
            var request = new RestRequest();
            //request.RequestFormat = DataFormat.Json;
            //request.AddHeader("x-rapidapi-host", "jikan1.p.rapidapi.com");
            //request.AddHeader("x-rapidapi-key", "SIGN-UP-FOR-KEY");
            var response = (await client.ExecuteAsync(request)).Content;

            return response;
        }

        private static string GenerateParameters(Dictionary<string, string> postBody)
        {
            string postData = null;

            if (postBody != null)
            {
                postData += '?';
                foreach (var item in postBody)
                {
                    postData += $"{item.Key}={item.Value}&";
                }
                postData = postData.Remove((postData.Length - 1), 1);
            }

            return postData;
        }
    }
}
