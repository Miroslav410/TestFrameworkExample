using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestFrameworkExample.Utilities
{
    public class BrowserUtility
    {
        IWebDriver driver;

        public IWebDriver ChromeInit() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://testpages.herokuapp.com/styled/index.html";
            return driver;
        }

        public IWebDriver EdgeInit()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://testpages.herokuapp.com/styled/index.html";
            return driver;
        }

        public IWebDriver FirefoxInit()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://testpages.herokuapp.com/styled/index.html";
            return driver;
        }

        public void Close() 
        {
            driver.Quit();
        }
    }
}
