using RestSharp;

namespace APICalls
{
    public class CustomersAPI
    {
        private WebApi _webApi;

        public CustomersAPI(WebApi webApi)
        {
            _webApi = webApi;
        }

       
        public IRestResponse ViewAnyCustomer(int id)
        {
            var request = new RestRequest("Customers/Page/" + id.ToString(), Method.GET);
            
            _webApi.AppendHeaders(request);
            return _webApi.RestClient.Execute(request);
        }

        public IRestResponse ViewCustomerWithId(string id)
        {
            var request = new RestRequest("Customers/" + id, Method.GET);
            _webApi.AppendHeaders(request);
            return _webApi.RestClient.Execute(request);
        }

        

    }
}
