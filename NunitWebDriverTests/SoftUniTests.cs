using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NunitWebDriverTests
{
    public class SoftUniTests
    {
        private WebDriver driver;
        [OneTimeSetUp]
        public void OpenBrowserAndNavigate()
        {
            //Add option to Chrome browser instance
            //var options = new ChromeOptions();
            //options.AddArgument("--headless");
            //this.driver = new ChromeDriver(options);

            this.driver = new ChromeDriver();

            driver.Url = "http://softuni.bg";
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown]

        public void ShutDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AssertMainPageTitle()
        {
            driver.Url = "http://softuni.bg";
            string expectedTitle = "Обучение по програмиране - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]

        public void Test_AssertAboutUsTitle()
        {
            var zaNasElement = driver.FindElement(By.CssSelector("#header-nav > div.toggle-nav.toggle-holder > ul > li:nth-child(1) > a > span"));
            zaNasElement.Click();

            string expectedTitle = "За нас - Софтуерен университет";

            Assert.That(driver.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void Test_Login_InvalidUsernameAndPassword()
        {
            driver.FindElement(By.CssSelector(".softuni-btn-primary")).Click();
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.CssSelector(".authentication-page")).Click();
            driver.FindElement(By.Id("username")).SendKeys("1111");
            driver.FindElement(By.CssSelector(".authentication-page")).Click();
            driver.FindElement(By.Id("password-input")).SendKeys("1111");
            driver.FindElement(By.CssSelector(".checkbox-icon")).Click();
            driver.FindElement(By.CssSelector(".softuni-btn")).Click();
            Assert.That(driver.FindElement(By.Id("username-error")).Text, Is.EqualTo("Невалиден формат на потребителското име."));
            driver.Close();
        }

        [Test]

        public void Test_Search_PositiveResults()
        {
            driver.Manage().Window.Maximize();

            //Click on Search button
            //#search-icon-container > a > span > i
            driver.FindElement(By.CssSelector(".header-search-dropdown-link .fa-search"))
                .Click();

            //Type search value and hit Enter
            var searchBox = driver.FindElement(By.CssSelector(".container > form #search-input"));
            searchBox.Click();
            searchBox.SendKeys("QA");
            searchBox.SendKeys(Keys.Enter);

            var resultField = driver.FindElement(By.CssSelector(".search-title")).Text;

            var expectedValue = "Резултати от търсене на “QA”";

            Assert.That(resultField, Is.EqualTo(expectedValue));

        }
    }
}