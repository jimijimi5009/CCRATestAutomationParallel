using CCRATestAutomation.Uttils;
using Gherkin.CucumberMessages.Types;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCRATestAutomation.Environment
{
    public class DriverManager
    {

        //protected static WebDriver driver;
        protected static Scenario scenarios;

        private static ThreadLocal<IWebDriver> tlDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            return tlDriver.Value ?? (tlDriver.Value = new WebDriverFactory(tlDriver).Init());
        }

    }
}
