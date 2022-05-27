using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkExample.BaseClass
{
    public class Base
    {
        public IWebDriver driver;

        [SetUp]
        public void Open() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://testpages.herokuapp.com/styled/index.html";
        }

        [TearDown]
        public void Close() 
        {
            driver.Quit();
        }
    }
}
