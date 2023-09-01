using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCRATestAutomation.Environment;
using CCRATestAutomation.Uttils;
using NUnit.Framework;
using Gherkin;

namespace CCRATestAutomation.CommonPages
{
    public class SeleniumElements
    {
        private readonly IWebDriver driver;
        private readonly object lockObject = new object();

        public SeleniumElements(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitUntilElementIsClickable(IWebElement element)
        {
            lock (lockObject)
            {
                long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
        }

        public void WaitUntilClickable(IWebElement element)
        {
            lock (lockObject)
            {
                try
                {
                    WaitUntilElementIsClickable(element);
                }
                catch (Exception)
                {
                    WaitUntilElementIsClickable(element);
                }
            }
        }

        public void WaitAndClick(IWebElement element)
        {
            lock (lockObject)
            {
                WaitUntilClickable(element);
                element.Click();
            }
        }

        public void WaitUntilTextIsVisible(IWebElement element, string testData)
        {
            lock (lockObject)
            {
                long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                wait.Until(ExpectedConditions.TextToBePresentInElement(element, testData));
            }
        }

        public void WaitUntilElementIsVisible(By locator)
        {
            lock (lockObject)
            {
                long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
        }

        public void WaitUntilElementIsVisible(string elementXPath)
        {
            lock (lockObject)
            {
                try
                {
                    long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                    new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime))
                        .Until(ExpectedConditions.ElementIsVisible(By.XPath(elementXPath)));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public bool IsElementPresent(IWebElement element)
        {
            lock (lockObject)
            {
                return element != null;
            }
        }

        public bool IsElePresent(By testData)
        {
            lock (lockObject)
            {
                bool flag = false;
                try
                {
                    flag = driver.FindElements(testData).Count > 0;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return flag;
            }
        }

        public bool IsCssVisible(By testData)
        {
            lock (lockObject)
            {
                bool flag = false;
                try
                {
                    string elementStyle = driver.FindElement(testData).GetAttribute("style");
                    flag = !(elementStyle.Equals("display: none;") || elementStyle.Equals("visibility: hidden"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
                return flag;
            }
        }

        public IWebElement EligibilityOrAvaility(By para1, By para2)
        {
            lock (lockObject)
            {
                IWebElement element = null;
                IWebElement element1;
                IWebElement element2;

                do
                {
                    try
                    {
                        element1 = driver.FindElement(para1);
                    }
                    catch (Exception)
                    {
                        element1 = null;
                    }
                    try
                    {
                        element2 = driver.FindElement(para2);
                    }
                    catch (Exception)
                    {
                        element2 = null;
                    }

                    if (element1 != null)
                    {
                        element = element1;
                    }
                    else if (element2 != null)
                    {
                        element = element2;
                    }
                } while (element == null);

                return element;
            }
        }

        public IList<IWebElement> GetDropdownListItems(By testData)
        {
            lock (lockObject)
            {
                return new SelectElement(driver.FindElement(testData)).Options;
            }
        }

        public void NavigateBackToPreviousPage()
        {
            lock (lockObject)
            {
                driver.Navigate().Back();
            }
        }

        public IWebElement GetRootElement(IWebElement element)
        {
            lock (lockObject)
            {
                return (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot", element);
            }
        }

        public string InitCap(string testData)
        {
            lock (lockObject)
            {
                return char.ToUpper(testData[0]) + testData.Substring(1).ToLower();
            }
        }

        public async Task WaitFor(int waitMillis)
        {
            await Task.Delay(waitMillis).ConfigureAwait(false);
        }

        public void ExplicitlyWaitForElementToBeClickable(IWebElement ele)
        {
            lock (lockObject)
            {
                long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                    wait.Until(ExpectedConditions.ElementToBeClickable(ele));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to Get the element After waiting {waitTime} Second...");
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public void WaitAndSendKeys(IWebElement element, string testData)
        {
            lock (lockObject)
            {
                ExplicitlyWaitForElementToBeClickable(element);
                element.SendKeys(testData);
            }
        }

        public void WaitForElementText(IWebElement ele, string text)
        {
            lock (lockObject)
            {
                long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                wait.Until(ExpectedConditions.TextToBePresentInElement(ele, text));
            }
        }

        public void ExplicitlyWaitForElementVisibility(By ele)
        {
            lock (lockObject)
            {
                long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                    wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(ele));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to Get the element After waiting {waitTime} Second...");
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public bool ExplicitlyWaitForElementText(IWebElement ele, string text)
        {
            lock (lockObject)
            {
                long waitTime = long.Parse(AppConfigReader.GetAppSetting("WaitTime"));
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
                    return wait.Until(ExpectedConditions.TextToBePresentInElement(ele, text));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to Get the Expected Text After waiting " + waitTime + "Second...");
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        public void HighlightElementBackground(IWebElement element, string flag)
        {
            lock (lockObject)
            {
                var js = (IJavaScriptExecutor)driver;

                if (flag.Equals("pass"))
                {
                    js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
                }
                else
                {
                    js.ExecuteScript("arguments[0].style.backgroundColor = '" + "red" + "'", element);
                }

                //Thread.Sleep(2000);
            }
        }

        public string GetText(IWebElement element)
        {
            lock (lockObject)
            {
                string getElement = null;
                try
                {
                    getElement = element.Text;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return getElement;
            }
        }

        public void ClickWithStrElement(string xpath)
        {
            lock (lockObject)
            {
                try
                {
                    driver.FindElement(By.XPath(xpath)).Click();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void ScrollToElement(IWebElement webElement)
        {
            lock (lockObject)
            {
                try
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoViewIfNeeded()", webElement);
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void ClickFromElements(IList<IWebElement> relements, string text)
        {
            lock (lockObject)
            {
                for (int i = 0; i < relements.Count; i++)
                {
                    string x = relements.ElementAt(i).Text;
                    if (x.ToLower().Contains(text.ToLower()) || x.Contains(text))
                    {
                        relements.ElementAt(i).Click();
                    }
                }
            }
        }

        public void ClickFromElementsWithEquleText(IList<IWebElement> relements, string text)
        {
            lock (lockObject)
            {
                for (int i = 0; i < relements.Count; i++)
                {
                    string x = relements.ElementAt(i).Text;
                    if (x.ToLower().Equals(text.ToLower()))
                    {
                        relements.ElementAt(i).Click();
                    }
                }
            }
        }

        public IList<string> GetAllText(IList<IWebElement> relements)
        {
            lock (lockObject)
            {
                IList<string> all_elements_text = new List<string>();

                for (int i = 0; i < relements.Count; i++)
                {
                    all_elements_text.Add(relements.ElementAt(i).Text);
                }

                return all_elements_text;
            }
        }

        public IList<string> GetAllAttributeText(IList<IWebElement> relements, string attbName)
        {
            lock (lockObject)
            {
                IList<string> all_elements_text = new List<string>();

                for (int i = 0; i < relements.Count; i++)
                {
                    all_elements_text.Add(relements.ElementAt(i).GetAttribute(attbName));
                }

                return all_elements_text;
            }
        }

        public List<string> GetSubstringFromText(List<string> strData, string openingStr, string closingStr)
        {
            lock (lockObject)
            {
                List<string> all_elements_text = new List<string>();
                for (int i = 0; i < strData.Count; i++)
                {
                    int start = strData[i].IndexOf(openingStr);
                    if (start == -1)
                    {
                        continue;
                    }

                    int end = strData[i].IndexOf(closingStr, start + openingStr.Length);
                    if (end == -1)
                    {
                        continue;
                    }

                    all_elements_text.Add(strData[i].Substring(start + openingStr.Length, end - start - openingStr.Length));
                }
                return all_elements_text;
            }
        }

        public string GetSubstringBetween(string strData, string openingStr, string closingStr)
        {
            lock (lockObject)
            {
                int start = strData.IndexOf(openingStr);
                if (start == -1)
                {
                    return null;
                }

                int end = strData.IndexOf(closingStr, start + openingStr.Length);
                if (end == -1)
                {
                    return null;
                }

                return strData.Substring(start + openingStr.Length, end - start - openingStr.Length);
            }
        }

        public void ClickButton(IWebElement element)
        {
            lock (lockObject)
            {
                element.Click();
            }
        }

        public void SendKeys(IWebElement element, string data)
        {
            lock (lockObject)
            {
                element.SendKeys(data);
            }
        }

        public List<string> GetAllText(IReadOnlyCollection<IWebElement> element)
        {
            lock (lockObject)
            {
                List<IWebElement> listFromUi = new List<IWebElement>(element);
                List<string> validations = new List<string>();

                for (int i = 0; i < listFromUi.Count; i++)
                {
                    validations.Add(listFromUi[i].Text);
                }
                return validations;
            }
        }

        public void SendKeyWithMethord(IWebElement element, string text)
        {
            lock (lockObject)
            {
                element.Clear();
                element.SendKeys(text);
            }
        }

        public bool IsDisplayedMethord(IWebElement element)
        {
            lock (lockObject)
            {
                return element.Displayed;
            }
        }

        public List<string> GetTableData(Table table, string getData)
        {
            lock (lockObject)
            {
                var getlistFromTable = from row in table.Rows select row[getData];
                List<string> listfromFetureFile = getlistFromTable.ToList();
                return listfromFetureFile;
            }
        }

        public void SelectByVal(IWebElement element, string value)
        {
            lock (lockObject)
            {
                SelectElement oSelect = new SelectElement(element);
                oSelect.SelectByValue(value);
            }
        }

        public void WaitUntillEleClickAble(IWebElement element)
        {
            lock (lockObject)
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            }
        }

        public void WaitNClick(IWebElement element)
        {
            lock (lockObject)
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                element.Click();
            }
        }
    }



}

