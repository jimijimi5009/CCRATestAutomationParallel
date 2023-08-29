using BoDi;
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

        private readonly IObjectContainer _objectContainer;
        private readonly IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = new WebDriverFactory(objectContainer).Init(); // Initialize WebDriver
            _objectContainer.RegisterInstanceAs(_driver, "Driver");
         
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
            _driver.Quit();
        }

        private void StartApplication()
        {
            //String executionEnvironment = new EnvironmentFactory().getBrowserExecutionEnvironment();
            //String appEnv = new EnvironmentFactory().getApplicationEnv(); ///QA, Stage;

   
            string url = AppConfigReader.GetAppSetting("url");

            _driver.Navigate().GoToUrl(url);
        }
    }
}
