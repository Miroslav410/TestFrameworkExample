using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkExample.Pages
{
    public class FormsAndWindowsViewPage
    {
        IWebDriver driver;

        public FormsAndWindowsViewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "_valuenumber")]
        public IWebElement liNumberValue { get; set; }


        [FindsBy(How = How.Id, Using = "_valuecolour")]
        public IWebElement liColorValue { get; set; }

        [FindsBy(How = How.Id, Using = "_valuedate")]
        public IWebElement liDateValue { get; set; }

        [FindsBy(How = How.Id, Using = "_valuedatetime")]
        public IWebElement liDateTimeValue { get; set; }

        [FindsBy(How = How.Id, Using = "_valueemail")]
        public IWebElement liEmailValue { get; set; }

        [FindsBy(How = How.Id, Using = "_valuemonth")]
        public IWebElement liMonthYearValue { get; set; }

        

        public void scrollDownToFullView() 
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(liNumberValue);
            actions.Perform();
        }



        public String returnColorValueFromView() 
        {
            return liColorValue.Text;
        }

        public String returnDateValueFromView() 
        {
            return liDateValue.Text;
        }

        public String returnDateTimeValueFromView() 
        {
            return liDateTimeValue.Text;
        }

        public String returnEmailValueFromView() 
        {
            return liEmailValue.Text;
        }

        public String returnMonthYearValueFromView() 
        {
            return liMonthYearValue.Text;
        }

        public String returnNumberValueFromView() 
        {
            return liNumberValue.Text;
        }
    }
}
