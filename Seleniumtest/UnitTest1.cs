using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Seleniumtest
{
    [TestClass]
    public class UnitTest1
    {
        WebDriver driver;
        const string expected = "Amritpal";
        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";
        }

        [TestMethod]
        public void OpenWebsit_PopName_check()
        {
           
            //Arrange
            var driver = new ChromeDriver();

            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";

            WebElement Submit = (WebElement)driver.FindElement(By.Id("submit"));

            //Act
            driver.FindElement(By.Id("forename")).SendKeys(expected);
            Submit.Click();

            //Assert

            var pop = driver.FindElement(By.ClassName("popup-message"));
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(1000)).Until(d => pop.Displayed);
            Assert.AreEqual(expected: "Hello " + expected, actual: pop.Text);

           

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
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000)).Until(d => ClickBtn.Text == "CLICK ME UP!");

            //Assert
            Assert.AreEqual(expected: "CLICK ME UP!", actual: ClickBtn.Text);
            //driver.Quit();
        }

        [TestMethod]
        public void OpenWebsite_Click_button_Up()
        {
            string btnDwonText = "CLICK ME DOWN!";
            string btnUpText = "CLICK ME UP!";
            //Arrange
            var driver = new ChromeDriver();
            driver.Url = "https://d18u5zoaatmpxx.cloudfront.net/#/";

            //Act
            var ClickBtn = driver.FindElement(By.ClassName("anibtn"));
            ClickBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(3000)).Until(d => ClickBtn.Text == btnUpText);
            ClickBtn.Click();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(2000)).Until(d => ClickBtn.Text
            == btnDwonText);

            //Assert
            Assert.AreEqual(expected: btnDwonText, actual: ClickBtn.Text);

            driver.Quit();

        }

        [TestMethod]
        public void EnterDetails_ClickButton_PopUpCheck()
        {
          new Toolbar(driver).ClickFormsButton();

          var form = new Form(driver);
           
          form.SetName("Amritpal");
          form.SetEmail("amritpal@gmail.com");
          form.SetState("QLD");
          form.ClickAgree();
          form.ClickSubmit();

            //Assert

            IWebElement PopMessage = driver.FindElement(By.ClassName("snackbar"));
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000)).Until(d => PopMessage.Displayed);

            Assert.AreEqual(expected: "Thanks for your feedback Amritpal", actual: PopMessage.Text);
          
        }


        [TestCleanup]
        public void CleanUp()
        {
           driver.Quit();
        }
    }

}  