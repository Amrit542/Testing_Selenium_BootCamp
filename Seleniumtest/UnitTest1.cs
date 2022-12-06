using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Seleniumtest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OpenWebsit_PopName_check()
        {
            const string expected = "Amritpal";
            //Arrange
            var driver = new ChromeDriver();

            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";

            WebElement Submit = (WebElement)driver.FindElement(By.Id("submit"));

            //Act
            driver.FindElement(By.Id("forename")).SendKeys(expected);
            Submit.Click();

            //Assert

            var pop = driver.FindElement(By.ClassName("popup-message"));
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(1000)).Until(d=>pop.Displayed);
            Assert.AreEqual(expected: "Hello " + expected, actual: pop.Text);

            driver.Quit();
        
        }

        [TestMethod]
        public void OpenWebsite_CLickButtonDown_Check()
        {
            //Arrange
            var driver = new ChromeDriver();

            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";

            //Act
            var ClickBtn = driver.FindElement(By.ClassName("anibtn"));
            ClickBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(1000)).Until(d => ClickBtn.Text == "CLICK ME UP!");

            //Assert
            Assert.AreEqual(expected: "CLICK ME UP!", actual: ClickBtn.Text);
            driver.Quit();
        }

        [TestMethod]
        public void OpenWebsite_Click_button_Up()
        {
            //Arrange
            var driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";

            //Act
            var ClickBtn = driver.FindElement(By.ClassName("anibtn"));
            ClickBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000)).Until(d => ClickBtn.Text == "CLICK ME UP!");
            ClickBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000)).Until(d => ClickBtn.Text == "CLICK ME DOWN!");

            //Assert
            Assert.AreEqual(expected: "CLICK ME DOWN!", actual: ClickBtn.Text);
            
            //driver.Quit();

        }
    }
}