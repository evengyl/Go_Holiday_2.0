using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Utils
{
    public class ControllerAPI : IControllerAPI
    {
        private HttpClient _client = new HttpClient();

        public ControllerAPI(Uri uri)
        {
            _client.BaseAddress = uri;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClientHandler handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) => { return true; };
        }
        

        // patie générique
        public TEntity GetAllAPI<TEntity>(string uri)
        {
            using (HttpResponseMessage response = _client.GetAsync(uri).Result)
            {
                response.EnsureSuccessStatusCode();
                string Json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<TEntity>(Json);
            }
        }

        public TEntity GetOneAPI<TEntity>(string uri, int id)
        {
            using (HttpResponseMessage response = _client.GetAsync(uri + "/" + id).Result)
            {
                response.EnsureSuccessStatusCode();
                string Json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<TEntity>(Json);
            }
        }


        public void PostAPI<TEntity>(string uri, TEntity model)
        {

            string jsonFilm = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(jsonFilm, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _client.PostAsync(uri, content).Result)
            {
                response.EnsureSuccessStatusCode();
            }
        }

        public TEntity Login<TEntity>(TEntity model)
        {

            string jsonFilm = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(jsonFilm, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _client.PostAsync("UserTodo/Login", content).Result)
            {
                response.EnsureSuccessStatusCode();
                string Json = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<TEntity>(Json);
            }
        }

        public string GetPublicKey()
        {
            using (HttpResponseMessage response = _client.GetAsync("UserTodo/GetPublicKey").Result)
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    string Json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<string>(Json);
                }
                catch(Exception e)
                {
                    return "Une erreur est survenue lors de l'appel de L'API";
                }
                
            }
        }



        public void PutAPI<TEntity>(string ui, TEntity item)
        {
            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _client.PutAsync(ui, content).Result)
            {
                response.EnsureSuccessStatusCode();
                if (!response.IsSuccessStatusCode) { throw new HttpRequestException(); }
            }
        }


        public void Delete(string uri, int id)
        {

            using (HttpResponseMessage response = _client.DeleteAsync(uri + "/" + id.ToString()).Result)
            {
                response.EnsureSuccessStatusCode();
            }
        }

        
    }
}
