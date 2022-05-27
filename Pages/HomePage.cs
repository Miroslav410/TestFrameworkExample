using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace TestFrameworkExample.Pages
{
    public class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "adminlogin")]
        public IWebElement cookieLoginExampleLink { get; set; }

        [FindsBy(How = How.Id, Using = "html5formtest")]
        public IWebElement formsAndWindowsLink { get; set; }

        public CookiesControllingPage clickOnCookieControllingPage() 
        {
            cookieLoginExampleLink.Click();
            return new CookiesControllingPage(driver);
        }

        public FormsAndWindowsPage clickOnFormsAndWindowsPage() 
        {
            formsAndWindowsLink.Click();
            return new FormsAndWindowsPage(driver);
        }

    }

}
