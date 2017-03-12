using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APICalls
{
    public class ProductsAPI
    {
        private WebApi _webApi;

        public ProductsAPI(WebApi webApi)
        {
            _webApi = webApi;
        }

        public IRestResponse ViewAnyProduct(int id)
        {
            var request = new RestRequest("Products/Page/" + id.ToString(), Method.GET);

            _webApi.AppendHeaders(request);
            return _webApi.RestClient.Execute(request);
        }

        public IRestResponse ViewProductrWithId(string id)
        {
            var request = new RestRequest("Product/" + id, Method.GET);
            _webApi.AppendHeaders(request);
            return _webApi.RestClient.Execute(request);
        }

    }
}
