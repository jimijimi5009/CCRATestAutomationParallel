using CCRATestAutomation.CommonPages;
using CCRATestAutomation.Environment;
using CCRATestAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;


namespace CCRATestAutomation.StepDefinitions
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [Binding]
    public  class CalculatorStepDefinitions
    {

        private IWebDriver driver;

        private CalculatorSPage calculatorPage;
        public CalculatorStepDefinitions()
        {
            driver = DriverManager.GetDriver();    
        }

        [Given(@"i navigate to google")]
        public void GivenINavigateToGoogle()
        {
            calculatorPage = new CalculatorSPage(driver);
            calculatorPage.enterData("i am here");
        }


    }
}