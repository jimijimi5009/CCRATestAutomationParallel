using CCRATestAutomation.Uttils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace CCRATestAutomation.Environment
{
    public class WebDriverFactory


    {
        private IWebDriver driver;

        private ThreadLocal<IWebDriver> tlDriver;

        public WebDriverFactory(ThreadLocal<IWebDriver> tlDriver)
        {
            this.tlDriver = tlDriver;
        }

        public IWebDriver Init()
        {
            try
            {
                string browser = GetBrowserName();
                string osName = OsUtill.GetOperatingSystem();

                if (osName.Contains("Win"))
                {
                    OsUtill.KillAllProcesses(browser);
                }

                driver = GetLocalDriver(browser, osName);
                driver.Manage().Window.Maximize();

                return driver;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private IWebDriver GetLocalDriver(string browser, string osName)
        {
            try
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        if (osName.Contains("Win"))
                        {
                            return SetChromeDriverForWin();
                        }
                        else if (osName.Contains("Mac"))
                        {
                            return SetChromeDriverForMac();
                        }
                        break;
                    case "firefox":
                        return SetFirefoxDriver();
                    case "edge":
                        return SetEdgeDriver();
                    default:
                        Console.WriteLine(browser + " is not a supported browser");
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return null;
        }

        public string GetBrowserName()
        {
            try
            {
                string jsonContent = JsonTool.ReadJsonFile("BrowsersList.json");
                string browserName = JsonTool.GetSpecificValue(jsonContent, "Browser");


                return browserName;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private IWebDriver SetChromeDriverForWin()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArguments("test-type");
                options.AddArguments("start-maximized");
                options.AddArguments("--enable-precise-memory-info");
                options.AddArguments("--disable-popup-blocking");
                options.AddArguments("--disable-default-apps");
                options.AddArguments("test-type=browser");
                options.AddArguments("--incognito");

                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

                IWebDriver driver = new ChromeDriver(options);

                tlDriver.Value = driver;

                Console.WriteLine("Starting Chrome browser");
                return driver;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw; // Re-throw the exception
            }
        }

        private IWebDriver SetChromeDriverForMac()
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                string downloadFilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "browser_downloads");
                Dictionary<string, object> chromePrefs = new Dictionary<string, object>
                {
                    ["profile.default_content_settings.popups"] = 0,
                    ["download.default_directory"] = downloadFilepath
                };
                options.AddArguments("test-type");
                options.AddArguments("disable-extensions");
                options.AddArguments("--ignore-certificate-errors");
                options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                options.AddUserProfilePreference("download.default_directory", downloadFilepath);
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                driver = new ChromeDriver(options);
                return driver;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private IWebDriver SetFirefoxDriver()
        {
            try
            {
                FirefoxOptions opts = new FirefoxOptions();
                opts.AddArguments("-private");
                new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig(), version: "latest");
                driver = new FirefoxDriver(opts);
                Console.WriteLine("Starting Firefox browser");
                return driver;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        private IWebDriver SetEdgeDriver()
        {
            try
            {
                EdgeOptions edgeOptions = new EdgeOptions();
                edgeOptions.AddArgument("-inprivate");
                new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig(), version: "latest");
                driver = new EdgeDriver(edgeOptions);
                Console.WriteLine("Starting Edge browser");
                return driver;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
