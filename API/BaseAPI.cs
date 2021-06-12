
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace NUnit.Tests1
{
    public class BaseAPI 
    {

        public static string baseURL = "http://api.qaauto.co.nz/api";
        public static string version = "v1";
        public static string token;
        

        public static string AuthToken(string auth)
        {
            var client = new RestClient($"{baseURL}/{version}/auth/login");
            var request = new RestRequest(Method.POST);
            //setting up header
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", token);
            //body
            request.AddParameter("application/json", auth, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //convert 
            string jsonData = response.Content;
            Token t = JsonConvert.DeserializeObject<Token>(jsonData);
            // TestContext.WriteLine(t.access_token);
            // token = t.access_token;
            return t.access_token;


        }
    }
}
