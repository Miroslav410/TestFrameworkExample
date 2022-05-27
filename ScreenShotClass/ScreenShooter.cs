using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkExample.ScreenShotClass
{
    public class ScreenShooter
    {
        //IWebDriver driver;

        public void TakeAScreenShot(IWebDriver driver) 
        {
            ITakesScreenshot screenshooter = driver as ITakesScreenshot;
            Screenshot sShot = screenshooter.GetScreenshot();
            sShot.SaveAsFile("..\\..\\..\\Screenshots\\Screenshot.jpeg");
        }
    }
}
