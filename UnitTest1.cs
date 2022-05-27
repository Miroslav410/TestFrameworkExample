using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using TestFrameworkExample.Utilities;
using TestFrameworkExample.Pages;
using System.Threading;
using System;
using OpenQA.Selenium.Interactions;
using System.Globalization;
using TestFrameworkExample.ScreenShotClass;

[assembly: Parallelizable(ParallelScope.Children)]
[assembly: LevelOfParallelism(4)]

namespace TestFrameworkExample
{
    [TestFixture]
    //[Parallelizable(ParallelScope.All)]
    //[FixtureLifeCycle(LifeCycle.SingleInstance)]
    public class Tests : BrowserUtility
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentReports() 
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"..\\..\\..\\ExtentReports\\Report.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose() 
        {
            extent.Flush();
        }

        
        [Test, Category("ChromeTests")]
        public void CookieControlLogginTestChrome0()
        {
            ExtentTest test = extent.CreateTest("Cookie Control Loggin Test Chrome0").Info("Test Started");

            var chromeDriverObj = new BrowserUtility().ChromeInit();

            HomePage homePageObj = new HomePage(chromeDriverObj);
            CookiesControllingPage cookiesControllingPageObj = homePageObj.clickOnCookieControllingPage();
            CookiesLoggedInPage cookiesLoggedInPageObj = cookiesControllingPageObj.loginFormFilling();
            cookiesLoggedInPageObj.deleteCookieAndRefreshPage(chromeDriverObj);
            

            chromeDriverObj.Close();
            test.Log(Status.Pass, "TEST PASSED.");
        }

        [Test, Category("FirefoxTests")]
        public void CookieControlLogginTestFirefox()
        {
            ExtentTest test = extent.CreateTest("Cookie Control Loggin Test Firefox").Info("Test Started");

            var firefoxDriverObj = new BrowserUtility().FirefoxInit();

            HomePage homePageObj = new HomePage(firefoxDriverObj);
            CookiesControllingPage cookiesControllingPageObj = homePageObj.clickOnCookieControllingPage();
            CookiesLoggedInPage cookiesLoggedInPageObj = cookiesControllingPageObj.loginFormFilling();
            cookiesLoggedInPageObj.deleteCookieAndRefreshPage(firefoxDriverObj);

            firefoxDriverObj.Close();
            test.Log(Status.Pass, "TEST PASSED.");
        }


        [Test, Category("EdgeTests")]
        public void CookieControlLogginTestEdge()
        {
            ExtentTest test = extent.CreateTest("Cookie Control Loggin Test Edge").Info("Test Started");

            var edgeDriverObj = new BrowserUtility().EdgeInit();

            HomePage homePageObj = new HomePage(edgeDriverObj);
            CookiesControllingPage cookiesControllingPageObj = homePageObj.clickOnCookieControllingPage();
            CookiesLoggedInPage cookiesLoggedInPageObj = cookiesControllingPageObj.loginFormFilling();
            cookiesLoggedInPageObj.deleteCookieAndRefreshPage(edgeDriverObj);

            edgeDriverObj.Close();
            test.Log(Status.Pass, "TEST PASSED.");
        }

        [Test, Category("ChromeTests")]
        public void CookieControlLogginTestChrome1()
        {
            ExtentTest test = extent.CreateTest("Cookie Control Loggin Test Chrome1").Info("Test Started");

            var chromeDriverObj = new BrowserUtility().ChromeInit();

            HomePage homePageObj = new HomePage(chromeDriverObj);
            CookiesControllingPage cookiesControllingPageObj = homePageObj.clickOnCookieControllingPage();
            CookiesLoggedInPage cookiesLoggedInPageObj = cookiesControllingPageObj.loginFormFilling();
            cookiesLoggedInPageObj.deleteCookieAndRefreshPage(chromeDriverObj);

            chromeDriverObj.Close();
            test.Log(Status.Pass, "TEST PASSED.");

        }

        [Test, Category("ChromeTests")]
        public void formsAndWindowsTest() 
        {
            ExtentTest test = extent.CreateTest("Forms And Windows Test").Info("Test Started");

            var chromeDriverObj = new BrowserUtility().ChromeInit();
            HomePage homePageObj = new HomePage(chromeDriverObj);

            test.Log(Status.Info, "Chrome browser launched");

            String color = "#FF00FF";
            String date = "12-20-2020";
            String dateTime = "12-26-2005\t11-53PM";
            String email = "gmail@gmail.com";
            String monthYear = "December\t2002";
            String number = "45";

            test.Log(Status.Info, "Values initialized");

            try
            {
                FormsAndWindowsPage formsAndWindowsPageObj = homePageObj.clickOnFormsAndWindowsPage();
                formsAndWindowsPageObj.enterColorHex(color);
                formsAndWindowsPageObj.enterDate(date);
                formsAndWindowsPageObj.enterDateTime(dateTime);
                formsAndWindowsPageObj.enterEmail(email);
                formsAndWindowsPageObj.enterMonthYear(monthYear);
                formsAndWindowsPageObj.enterNumber(number);

                test.Log(Status.Info, "Formatting values for comparison");

                String[] dateFragments = date.Split("-");
                

                //First date formatted
                String formattedFirstDate = dateFragments[2] + "-" + dateFragments[0] + "-" + dateFragments[1];

                String[] dateTimeSeparated = dateTime.Split("\t");

                String dateSeparated = dateTimeSeparated[0];
                String timeSeparated = dateTimeSeparated[1];

                dateFragments = dateSeparated.Split("-");
                String formattedSecondDate = dateFragments[2] + "-" + dateFragments[0] + "-" + dateFragments[1];

                String partOfDay = timeSeparated.Substring(5);
                String[] timeFragments = timeSeparated.Replace(partOfDay, "").Split("-");

                int hourNum = Convert.ToInt32(timeFragments[0]);
                String minutesString = timeFragments[1];

                if (partOfDay.ToLower().Equals("pm"))
                {
                    hourNum += 12;
                }

                String hourString = Convert.ToString(hourNum);

                if (hourString.Length < 2)
                {
                    hourString = "0" + hourString;
                }

                //DateTime value formatted
                String formattedSecondDateAndTime = formattedSecondDate + "T" + hourString + ":" + minutesString;

                String[] monthYearSeparated = monthYear.Split("\t");

                int monthNumber = DateTime.ParseExact(monthYearSeparated[0], "MMMM", CultureInfo.CurrentCulture).Month;

                String monthNumString = Convert.ToString(monthNumber);

                if (monthNumString.Length < 2)
                {
                    monthNumString = "0" + monthNumString;
                }

                //MonthYear value formatted
                String formattedMonthYear = monthYearSeparated[1] + "-" + monthNumString;

                FormsAndWindowsViewPage formsViewPage = formsAndWindowsPageObj.submitEnteredDataAndNavigateToViewPage();

                test.Log(Status.Info, "Form submitted");

                test.Log(Status.Info, "Comparing entered values with values from view page");

                formsViewPage.scrollDownToFullView();

                String colorFromView = formsViewPage.returnColorValueFromView();
                String dateFromView = formsViewPage.returnDateValueFromView();
                String dateTimeFromView = formsViewPage.returnDateTimeValueFromView();
                String emailFromView = formsViewPage.returnEmailValueFromView();
                String monthYearFromView = formsViewPage.returnMonthYearValueFromView();
                String numberFromView = formsViewPage.returnNumberValueFromView();

                if (!(color.ToLower().Equals(colorFromView.ToLower())))
                {
                    Assert.Fail("Actual value is: " + colorFromView + "\n" + "Expected value is: " + color);
                }

                if (!(formattedFirstDate.ToLower().Equals(dateFromView.ToLower())))
                {
                    Assert.Fail("Actual value is: " + dateFromView + "\n" + "Expected value is: " + formattedFirstDate);
                }

                if (!(formattedSecondDateAndTime.ToLower().Equals(dateTimeFromView.ToLower())))
                {
                    Assert.Fail("Actual value is: " + dateTimeFromView + "\n" + "Expected value is: " + formattedSecondDateAndTime);
                }

                if (!(email.ToLower().Equals(emailFromView.ToLower())))
                {
                    Assert.Fail("Actual value is: " + emailFromView + "\n" + "Expected value is: " + email);
                }

                if (!(formattedMonthYear.ToLower().Equals(monthYearFromView.ToLower())))
                {
                    Assert.Fail("Actual value is: " + monthYearFromView + "\n" + "Expected value is: " + formattedMonthYear);
                }

                if (!(number.ToLower().Equals(numberFromView.ToLower())))
                {
                    Assert.Fail("Actual value is: " + numberFromView + "\n" + "Expected value is: " + number);
                }

                test.Log(Status.Pass, "TEST PASSED. All values are the same as the values from view page");
                
            }
            catch (Exception e)
            {
                ScreenShooter ss = new ScreenShooter();
                ss.TakeAScreenShot(chromeDriverObj);
                
                test.Log(Status.Fail, "TEST FAILED. Some values are not equal. Test error: \n" + e.ToString());
                
                Assert.Fail(e.StackTrace);

                //throw e;
            }
            finally 
            {
                chromeDriverObj.Close();
            }
        }

    }
}