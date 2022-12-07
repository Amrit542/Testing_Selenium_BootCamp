using OpenQA.Selenium;

namespace Seleniumtest
{
    internal class Toolbar
    {
        public WebDriver driver;

        public Toolbar(WebDriver driver)
        {
            this.driver = driver;
        }

        internal void ClickFormsButton()
        {
            driver.FindElement(By.CssSelector("[aria-label=forms].v-btn")).Click();
        }
    }
}