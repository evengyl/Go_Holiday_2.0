using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Controller.API.Login
{
    public class SignUpSystemAPI : ControllerAPI
    {
        public SignUpSystemAPI(Uri uri) : base(uri)
        {
        }

        public void SignUp<TEntity>(TEntity model)
        {
            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _client.PostAsync("User/Create", content).Result)
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public int VerifyEmail(string email)
        {
            string json = JsonConvert.SerializeObject(new { Email = email });
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _client.PostAsync("User/VerifyEmail", content).Result)
            {
                response.EnsureSuccessStatusCode();
                var respSerialized = response.Content.ReadAsStringAsync().Result;

                return Int32.Parse(respSerialized);
            }
        }
    }
}
