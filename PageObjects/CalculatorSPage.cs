using CCRATestAutomation.CommonPages;
using OpenQA.Selenium;


namespace CCRATestAutomation.PageObjects
{
    public class CalculatorSPage
    {

        private readonly IWebDriver _driver;
        private readonly SeleniumElements _seleniumElements;

        private IWebElement TextBox => _driver.FindElement(By.XPath("//*[@type='search']"));

        public CalculatorSPage(IWebDriver driver)
        {
            _driver = driver;
            _seleniumElements = new SeleniumElements(driver);
        }

        public void enterData(string data)
        {
            _seleniumElements.WaitAndSendKeys(TextBox, data);

            Console.WriteLine(data);
           
        }
    }
}
