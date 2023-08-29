using BoDi;
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


        private readonly IObjectContainer _objectContainer;
        private readonly IWebDriver _driver;

        public DriverManager(IObjectContainer objectContainer, IWebDriver driver)
        {
            _objectContainer = objectContainer;
            _driver = driver;
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
