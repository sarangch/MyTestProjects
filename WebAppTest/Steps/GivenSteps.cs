using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PortalUI;
using APICalls;

namespace WebAppTest.Steps
{
    [Binding]
    class GivenSteps
    {
        [Given(@"I do the test in (.*) browser")]
        public void GivenIDoTheTestInBrowser(string browserName)
        {
            if (!(ScenarioContext.Current.ContainsKey("Driver")))
            {
                var Driver = new BrowserObject(browserName);
                ScenarioContext.Current.Clear();
                ScenarioContext.Current.Add("Driver", Driver);
                Driver.BrowserMaximize();
            }
        }

        [Given(@"I navigate to (.*) url")]
        public void GivenINavigateToSampleUrl(string url)
        {
            var Driver = GetDriverFromCurrentContext();
            Driver.Browse(url);
        }

        [Given(@"Eneter the folliwing texts in the fields by Id")]
        public void WhenEneterTheFolliwingValuesInTheFieldsById(Table table)
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");

            string field;
            string value;

            for (int i = 0; i < table.Header.Count(); i++)
            {
                field = table.Header.ElementAt(i);
                value = table.Rows[0][i];
                Driver.ElementSetValue("Id", field, value);
            }
        }

        [Given(@"press the button with this property")]
        public void WhenPressTheButtonWithProperty(Table table)
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");

            string field;
            string value;

            field = table.Header.ElementAt(0);
            value = table.Rows[0][0];
            Driver.PressButton(field, value);
        }

        [Given(@"I wait for (.*) msec")]
        public void GivenIWaitForMsec(int val)
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");
            Driver.BrowserWait(val);
        }

        [Given(@"I use the following credentials for authentication")]
        public void GivenIUseTheFollowingCredentialsForAuthentication(Table table)
        {
            var webApi = GetWebApiFromCurrentContext();
            string field;
            string value;

            for (int i = 0; i < table.Header.Count(); i++)
            {
                field = table.Header.ElementAt(i);
                value = table.Rows[0][i];
                webApi.UpdateHeaders(field,value);
            }
            ScenarioContext.Current.Set<WebApi>(webApi, "webApi");
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
