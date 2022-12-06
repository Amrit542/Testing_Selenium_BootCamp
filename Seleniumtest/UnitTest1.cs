using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Seleniumtest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = new ChromeDriver();

            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";

            WebElement Submit = (WebElement)driver.FindElement(By.Id("submit"));

            driver.FindElement(By.Id("forename")).SendKeys("Amritpal");
            Submit.Click();

            driver.Quit();
            


        }
    }
}