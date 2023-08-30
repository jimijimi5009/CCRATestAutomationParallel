using BoDi;
using CCRATestAutomation.CommonPages;
using CCRATestAutomation.Environment;
using CCRATestAutomation.Uttils;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow;
using TechTalk.SpecFlow;

namespace CCRATestAutomation.Hooks
{

    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [Binding]
    public class Hooks
    {

        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new WebDriverFactory(_objectContainer).Init(); // Initialize WebDriver
            _objectContainer.RegisterInstanceAs(_driver);
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
