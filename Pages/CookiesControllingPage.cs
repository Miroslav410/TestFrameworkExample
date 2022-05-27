using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestFrameworkExample.Pages
{
    public class CookiesControllingPage
    {
        IWebDriver driver;

        public CookiesControllingPage(IWebDriver driver) 
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        public IWebElement inputUsername { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        public IWebElement inputPassword { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement buttonLogin { get; set; }

        public CookiesLoggedInPage loginFormFilling() 
        {
            inputUsername.SendKeys("Admin");
            inputPassword.SendKeys("AdminPass");
            buttonLogin.Click();
            return new CookiesLoggedInPage(driver);
        }

    }
}
