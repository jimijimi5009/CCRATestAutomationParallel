using CCRATestAutomation.CommonPages;
using OpenQA.Selenium;


namespace CCRATestAutomation.PageObjects
{
    public class CalculatorSPage
    {

        private IWebDriver driver;
        private SeleniumElements seleniumElements;

        private IWebElement textBox => driver.FindElement(By.XPath("//*[@type='search']"));

        public CalculatorSPage(IWebDriver driver)
        {
            this.driver = driver;
            this.seleniumElements = new SeleniumElements(driver);
        }

        public void enterData(string data)
        {
            seleniumElements.WaitAndSendKeys(textBox, data);

            Console.WriteLine(data);
           
        }
    }
}
