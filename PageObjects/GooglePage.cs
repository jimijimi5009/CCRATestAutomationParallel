using CCRATestAutomation.CommonPages;
using OpenQA.Selenium;

namespace CCRATestAutomation.PageObjects
{
    public class GooglePage
    {

        private readonly IWebDriver _driver;
        private readonly SeleniumElements _seleniumElements;

        private IWebElement TextBox => _driver.FindElement(By.XPath("//*[@type='search']"));
        private IWebElement clickSearchBtn => _driver.FindElement(By.XPath("(//*[@name=\"btnK\"])[2]"));

        public GooglePage(IWebDriver driver)
        {
            _driver = driver;
            _seleniumElements = new SeleniumElements(driver);
        }

        public void enterData(string data)
        {
            _seleniumElements.HighlightElementBackground(TextBox, "pass");
            _seleniumElements.WaitAndSendKeys(TextBox, data);
          

            Console.WriteLine(data);
           
        }

        internal void clickSearch()

        {
           //_seleniumElements.HighlightElementBackground(clickSearchBtn, "pass");
            _seleniumElements.WaitAndClick(clickSearchBtn);
            Thread.Sleep(4000);
        }
    }
}
