using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestFrameworkExample.Pages
{
    public class CookiesLoggedInPage
    {
        IWebDriver driver;

        public CookiesLoggedInPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void deleteCookieAndRefreshPage(IWebDriver driver) 
        {
            // remove cookie
            driver.Manage().Cookies.DeleteCookieNamed("loggedin");
            driver.Navigate().Refresh();

            Thread.Sleep(5000);

            // create and add cookie
            Cookie ck = new Cookie("loggedin", "Admin");

            driver.Manage().Cookies.AddCookie(ck);
            driver.Navigate().Refresh();

            Thread.Sleep(5000);
        }
    }
}
