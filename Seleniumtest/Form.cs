using OpenQA.Selenium;
using System.Xml.Linq;

namespace Seleniumtest
{
    internal class Form
    {
        public WebDriver driver;

        public Form(WebDriver driver)
        {
            this.driver = driver;
        }

        internal void ClickAgree()
        {
            driver.FindElement(By.CssSelector("[for=agree]")).Click();
        }

        internal void SetState(string DesiredState)
        {
            driver.FindElement(By.ClassName("v-select__selections")).Click();

            var listStates = driver.FindElements(By.ClassName("v-list-item__content"));
            foreach ( var state in listStates)
            {
                if((string)state.GetAttribute("innerText") == DesiredState)
                {
                    state.Click();
                }

            }

        }

        internal void ClickSubmit()
        {
            var s = (WebElement)driver.FindElements(By.CssSelector("button > span.v-btn__content"))[1];
            s.Click();
        }

        internal void SetEmail(string Email)
        {
            driver.FindElement(By.Id("email")).SendKeys(Email);
        }

        internal void SetName(string name)
        {
            driver.FindElement(By.Id("name")).SendKeys(name);
        }
    }
}