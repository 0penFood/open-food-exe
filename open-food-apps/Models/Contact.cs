using Newtonsoft.Json.Linq;
using open_food_apps.Models.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace open_food_apps.Models
{
    
    internal class Contact : IContact
    {
        GlobalData globalDt;
        public Contact(GlobalData globalData)
        {
            globalDt = globalData;
        }

        public string EncryptMdp(string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                return Encoding.ASCII.GetString(mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password)));
            }
        }

        public bool Connect(string email, string password)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("email", email);
            dict.Add("password", password);

            var client = new HttpClient();
            var res = client.PostAsync("http://135.125.103.44:8081/auth/login", new FormUrlEncodedContent(dict)).GetAwaiter().GetResult();


            if(res.IsSuccessStatusCode)
            {
                Repository lp = JsonSerializer.Deserialize<Repository>(res.Content.ReadAsStream());
                globalDt.Token = lp.access_token;
            }
            return res.IsSuccessStatusCode;
        }

        public async void UnSerializedJson(HttpResponseMessage response, string type)
        {
            //var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            //List<Repository> listRepositories = new List<Repository>();
            //listRepositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);


            //System.Text.Json.JsonSerializer("");

            switch(type)
            {
                case "Repository":
                    Repository lp = JsonSerializer.Deserialize<Repository>(response.Content.ReadAsStream());
                    break;

                case "User":
                    User user = JsonSerializer.Deserialize<User>(response.Content.ReadAsStream());
                    break;
            }
        }

        public async Task<string> RecoverDataAllUser()
        {
            Dictionary<int, List<string>> dictUserData = new Dictionary<int, List<string>>();

            return await GetRequest("users");
        }

        private async Task<string> GetRequest(string path)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization
                     = new AuthenticationHeaderValue("Bearer", globalDt.Token);

            HttpResponseMessage response = await client.GetAsync(path);

            //return await UnSerializedJson(response, "User");
            return "";
        }

        public async Task<string> PostUser(Dictionary<string, string> keyValues, string type)
        {
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", globalDt.Token);

            string addPath = "";
            switch (type)
            {
                case "Restaurant":
                    addPath = "/restaurant";
                    break;

                case "Driver":
                    addPath = "/delivery";
                    break;

                case "Admin":
                    addPath = "/admin";
                    break;

                default:
                    addPath = "";
                    break;
            }

            var returnPost = client.PostAsync("http://135.125.103.44:8081/users"+ addPath, new FormUrlEncodedContent(keyValues)).GetAwaiter().GetResult();

            string valreturn = await returnPost.Content.ReadAsStringAsync();

            return valreturn;
        }
    }
}
