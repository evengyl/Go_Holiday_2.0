using Go_Holiday_2._0.Models.ModelsView.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Controller.API.Login
{
    public class EditUserSystemAPI : ControllerAPI
    {
        public EditUserSystemAPI(Uri uri) : base(uri)
        {
        }

        public void EditUser(UserInfos model)
        {
            string json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage response = _client.PostAsync("User/Update", content).Result)
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
