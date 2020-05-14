using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Controller.API
{
    public interface IControllerAPI
    {
        TEntity GetAllAPI<TEntity>(string uri);
        TEntity GetOneAPI<TEntity>(string uri, int id);
        void PostAPI<TEntity>(string uri, TEntity model);
        void PutAPI<TEntity>(string ui, TEntity model);
        void Delete(string uri, int id);
        string GetPublicKey();
    }
}
