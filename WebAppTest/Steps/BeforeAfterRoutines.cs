using TechTalk.SpecFlow;
using APICalls;
namespace WebAppTest.Steps
{
    [Binding]
    class BeforeAfterRoutines
    {
        [AfterScenario]
        public static void AfterScenarioIsRun()
        {
            //var Driver = ScenarioContext.Current.Get<BrowserObject>("Driver");
            //Driver.BrowserClose();
        }

        [BeforeScenario]
        public static void BeforeScenarioIsRun()
        {

            if (!(ScenarioContext.Current.ContainsKey("webApi")))
            {
                var webApi = new WebApi(TestSettings.Default.ApiUrl);
                ScenarioContext.Current.Add("webApi", webApi);
            }

        }
    }
}