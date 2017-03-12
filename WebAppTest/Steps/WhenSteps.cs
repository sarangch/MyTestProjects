using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PortalUI;
using APICalls;

namespace WebAppTest.Steps
{
    [Binding]
    class WhenSteps
    {
        [When(@"I navigate to (.*) url")]
        public void WhenINavigateToSampleUrl(string url)
        {
            var Driver = GetDriverFromCurrentContext();
            Driver.Browse(url);
        }

        [When(@"I wait for (.*) msec")]
        public void GivenIWaitForMsec(int val)
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");
            Driver.BrowserWait(val);
        }


        [When(@"Eneter the folliwing texts in the fields by Id")]
        public void WhenEneterTheFolliwingValuesInTheFieldsById(Table table)
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");

            string field;
            string value;

            for (int i = 0; i < table.Header.Count(); i++)
            {
                field = table.Header.ElementAt(i);
                value = table.Rows[0][i];
                Driver.ElementSetValue("Id",field,value);
            }
        }

        [When(@"press the button with this property")]
        public void WhenPressTheButtonWithProperty(Table table)
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");

            string field;
            string value;

            field = table.Header.ElementAt(0);
            value = table.Rows[0][0];
            Driver.PressButton(field,value);
        }

        [When(@"I send (.*) web request to (.*) with the following parameters")]
        public void WhenISendWebRequestWithParameters(string methodName, string apiName, Table table)
        {
            var webApi = GetWebApiFromCurrentContext();
            Type t = null;
            object instance = null;
            switch (apiName)
            {
                case "CustomersAPI":
                    t = typeof(CustomersAPI);
                    instance = webApi.CustomersAPI;
                    break;
                case "ProductsAPI":
                    t = typeof(ProductsAPI);
                    instance = webApi.ProductsAPI;
                    break;
                
            }

            if (t != null && instance != null)
            {
                object[] arg = table.FirstRowArgs();
                

                t.InvokeMethod(methodName, instance, arg);
            }
            else
            {
                throw new NotImplementedException(string.Format("{0} type not defined.", apiName));
            }
        }

        [When(@"I send (.*) web request to (.*) with no parameters")]
        public void WhenISendWebRequestWithNoParameters(string methodName, string apiName)
        {
            var webApi = GetWebApiFromCurrentContext();
            Type t = null;
            object instance = null;
            switch (apiName)
            {
                case "CompaniesAPI":
                    t = typeof(CompaniesAPI);
                    instance = webApi.CompaniesAPI;
                    break;

            }

            if (t != null && instance != null)
            {

                t.InvokeMethod(methodName, instance);
            }
            else
            {
                throw new NotImplementedException(string.Format("{0} type not defined.", apiName));
            }
        }







        private BrowserObject GetDriverFromCurrentContext()
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");
            if (Driver == null)
            {
                throw new InvalidOperationException("Driver does not exist in the current context");
            }

            return Driver;
        }

        private WebApi GetWebApiFromCurrentContext()
        {
            var webApi = ScenarioContext.Current.Get<WebApi>("webApi");

            if (webApi == null)
            {
                throw new InvalidOperationException("webApi does not exist in the current context.");
            }

            return webApi;
        }
    }
}
