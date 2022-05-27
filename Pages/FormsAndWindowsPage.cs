using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkExample.Pages
{
    public class FormsAndWindowsPage
    {
        IWebDriver driver;

        public FormsAndWindowsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "colour-picker")]
        public IWebElement inputColourPicker { get; set; }

        [FindsBy(How = How.Id, Using = "date-picker")]
        public IWebElement inputDatePicker { get; set; }

        [FindsBy(How = How.Id, Using = "date-time-picker")]
        public IWebElement inputDateTimePicker { get; set; }

        [FindsBy(How = How.Id, Using = "email-field")]
        public IWebElement inputEmail { get; set; }

        [FindsBy(How = How.Id, Using = "month-field")]
        public IWebElement inputMonthYear { get; set; }

        [FindsBy(How = How.Id, Using = "number-field")]
        public IWebElement inputNumber { get; set; }

        [FindsBy(How = How.Name, Using = "submitbutton")]
        public IWebElement buttonSubmit { get; set; }


        public void enterColorHex(String color) 
        {
            inputColourPicker.Clear();
            inputColourPicker.SendKeys(color);
        }

        public void enterDate(String date) 
        {
            inputDatePicker.Clear();
            inputDatePicker.SendKeys(date);
        }

        public void enterDateTime(String dateTime) 
        {
            inputDateTimePicker.Clear();
            inputDateTimePicker.SendKeys(dateTime);
        }

        public void enterEmail(String email) 
        {
            inputEmail.Clear();
            inputEmail.SendKeys(email);
        }

        public void enterMonthYear(String monthYear) 
        {
            inputMonthYear.Clear();
            inputMonthYear.SendKeys(monthYear);
        }

        public void enterNumber(String number) 
        {
            inputNumber.Clear();
            inputNumber.SendKeys(number);
        }

        public FormsAndWindowsViewPage submitEnteredDataAndNavigateToViewPage() 
        {
            buttonSubmit.Click();

            return new FormsAndWindowsViewPage(driver);
        }
    }
}
