using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Controller.API
{
    public class ControllerAPI : IControllerAPI
    {
        protected HttpClient _client;

        public ControllerAPI(Uri uri)
        {
            HttpClientHandler handler = new HttpClientHandler() { SslProtocols = SslProtocols.Tls12 };
            //la configuration de l'api étant sur le console et non en applicatif, le protocole ssl doit être en SSL12 (ssl 1.2)
            handler.ServerCertificateCustomValidationCallback = (request, cert, chain, errors) => { return true; };
            _client = new HttpClient(handler);

            _client.BaseAddress = uri;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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


        public string GetPublicKey()
        {
            using (HttpResponseMessage response = _client.GetAsync("User/GetPublicKey").Result)
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    string Json = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<string>(Json);
                }
#pragma warning disable CS0168 // La variable 'e' est déclarée, mais jamais utilisée
                catch (Exception e)
#pragma warning restore CS0168 // La variable 'e' est déclarée, mais jamais utilisée
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
