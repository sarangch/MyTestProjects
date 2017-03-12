using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PortalUI;
using APICalls;
using RestSharp;
using System.Net;

namespace WebAppTest.Steps
{
    [Binding]
    class ThenSteps
    {
        [Then(@"There should be elements with these properties")]
        public void ThenThereShouldBeElementsWithThisProperties(Table table)
        {
            int cntr = 0;
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");

            string field;
            string value;

            for (int i = 0; i < table.Header.Count(); i++)
            {
                field = table.Header.ElementAt(i);
                value = table.Rows[0][i];
                if (!Driver.ElementExist(field,value))
                {
                    cntr++;
                }
            }
            Assert.AreEqual(cntr,0);
            ScenarioContext.Current.Set<BrowserObject>(Driver, "Driver");
            //Driver.BrowserClose();
        }


        [Then(@"There should be element located by (.*) with the following locator and text")]
        public void ThenThereShouldBeElementLocatedByWithTheFollowingLocatorAndText(string locator, Table table)
        {
            var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");
            string field = table.Header.ElementAt(0);
            string value = table.Rows[0][0];

            string result = Driver.ElementGetText(locator,field);
            Assert.AreEqual(result, value);

        }




        [Then(@"I should receive the following response Status Code (.*)")]
        public void ThenIShouldReceiveTheFollowingResponseStatusCode(string code)
        {
            var response = ScenarioContext.Current.Get<IRestResponse>("response");
            var statusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), code);
            Assert.AreEqual(statusCode, response.StatusCode);



            var webApi = ScenarioContext.Current.Get<WebApi>("webApi");

            webApi.ResponseJson = response.Content.ToString();
            ScenarioContext.Current.Set<WebApi>(webApi, "webApi");
            
        }

    }



}
