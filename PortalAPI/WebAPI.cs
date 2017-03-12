using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace APICalls
{
    public class WebApi
    {
        public RestClient RestClient
        {
            get;
            private set;
        }

        public CompaniesAPI CompaniesAPI { get; private set; }
        public CustomersAPI CustomersAPI { get; private set; }
        public ProductsAPI ProductsAPI { get; private set; }
        public SalesPersonsAPI SalesPersonsAPI { get; private set; }

        public string ResponseJson { get; set; }
        public Dictionary<string, string> Headers { get; set; }


        public WebApi(string baseUrl)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            RestClient = new RestClient(baseUrl);

            Headers = new Dictionary<string, string>();
            Headers.Add("Accept", "application/json");
            Headers.Add("api-auth-id", "");
            Headers.Add("api-auth-signature", "");
            
            CompaniesAPI = new CompaniesAPI(this);
            CustomersAPI = new CustomersAPI(this);
            ProductsAPI = new ProductsAPI(this);
            SalesPersonsAPI = new SalesPersonsAPI(this);
        }

        public int UpdateHeaders(string key, string value)
        {
            if (Headers.ContainsKey(key))
            {
                Headers[key] = value.ToString();
            }

            return Headers.Count;
        }

        public void AppendHeaders(IRestRequest request)
        {
            foreach (var header in Headers)
            {
                request.AddHeader(header.Key, header.Value);
            }
        }
    }
}
