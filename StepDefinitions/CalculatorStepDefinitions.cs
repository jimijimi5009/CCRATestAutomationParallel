using BoDi;
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


        private readonly IObjectContainer _objectContainer;
        private CalculatorSPage calculatorPage;
        private IWebDriver _driver;

        public CalculatorStepDefinitions(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = _objectContainer.Resolve<IWebDriver>();
        }

        [Given(@"i navigate to google")]
        public void GivenINavigateToGoogle()
        {
            calculatorPage = new CalculatorSPage(_driver);
            calculatorPage.enterData("i am here");
        }


    }
}