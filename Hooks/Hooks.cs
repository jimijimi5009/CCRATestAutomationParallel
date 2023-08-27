using CCRATestAutomation.CommonPages;
using CCRATestAutomation.Environment;
using CCRATestAutomation.Uttils;
using OpenQA.Selenium;
using SpecFlow;
using TechTalk.SpecFlow;

namespace CCRATestAutomation.Hooks
{

    [Binding]
    public class Hooks 
    {

        private IWebDriver driver;

        public Hooks(IWebDriver driver)
        {
            this.driver = driver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            StartApplication();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Close the Driver
            driver.Quit();
        }

        private void StartApplication()
        {
            //String executionEnvironment = new EnvironmentFactory().getBrowserExecutionEnvironment();
            //String appEnv = new EnvironmentFactory().getApplicationEnv(); ///QA, Stage;

            string url = AppConfigReader.GetAppSetting("url");

            driver.Navigate().GoToUrl(url);
        }
    }
}
