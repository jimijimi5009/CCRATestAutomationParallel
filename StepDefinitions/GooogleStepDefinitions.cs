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
    public class GooogleStepDefinitions
    {


        private readonly IObjectContainer _objectContainer;
        private GooglePage calculatorPage;
        private IWebDriver _driver;

        public GooogleStepDefinitions(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = _objectContainer.Resolve<IWebDriver>();

        }

        [Given(@"i navigate to google")]
        public void GivenINavigateToGoogle()
        {

        }

        [Then(@"i enter  ""([^""]*)"" Data on Search bar")]
        public void ThenIEnterDataOnSearchBar(string p0)
        {
            calculatorPage = new GooglePage(_driver);    
            calculatorPage.enterData(p0);
        }

        [Then(@"i Click Search")]
        public void ThenIClickSearch()
        {
            calculatorPage.clickSearch();
            Thread.Sleep(5000);
        }



    }
}