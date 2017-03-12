using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APICalls
{
    public class CompaniesAPI
    {
        private WebApi _webApi;

        public CompaniesAPI(WebApi webApi)
        {
            _webApi = webApi;
        }

        public IRestResponse ViewCompanies()
        {
            var request = new RestRequest("Companies", Method.GET);

            _webApi.AppendHeaders(request);
            return _webApi.RestClient.Execute(request);
        }
    }
}
