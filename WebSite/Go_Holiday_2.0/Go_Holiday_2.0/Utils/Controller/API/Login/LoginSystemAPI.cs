using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Controller.API.Login
{
    public class LoginSystemAPI : ControllerAPI
    {
        public LoginSystemAPI(Uri uri) : base(uri)
        {
        }


        public TEntity2 Login<TEntity, TEntity2>(TEntity model)
        {

            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = _client.PostAsync("User/Login", content).Result)
            {
                response.EnsureSuccessStatusCode();
                string Json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<TEntity2>(Json);
            }
        }

    }
}
