using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICalls
{
    public class SalesPersonsAPI
    {
        private WebApi _webApi;

        public SalesPersonsAPI(WebApi webApi)
        {
            _webApi = webApi;
        }
    }
}
