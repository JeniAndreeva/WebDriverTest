using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace DataDrivenTestingCalculator
{
    public class WebDriverCalculatorTests

    {
        private ChromeDriver driver;

        [OneTimeSetUp]

        public void OpenAndNavigate()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://number-calculator.nakov.repl.co/";

        }

        [OneTimeTearDown]

        public void ShutDown()
        {
            driver.Quit();
        }
        //Tests valid integers
        [TestCase("5", "6", "+", "Result: 11")]
        [TestCase("15", "6", "-", "Result: 9")]
        [TestCase("15", "3", "/", "Result: 5")]
        [TestCase("5", "3", "*", "Result: 15")]
        [TestCase("-5", "3", "+", "Result: -2")]
        [TestCase("-15", "5", "/", "Result: -3")]
        [TestCase("5", "3", "*", "Result: 15")]
        [TestCase("5", "-3", "+", "Result: 2")]
        [TestCase("5", "-3", "*", "Result: -15")]

        //Test valid decimal numbers
        [TestCase("5.23", "3.88", "+", "Result: 9.11")]
        [TestCase("3.14", "12.763", "-", "Result: -9.623")]
        [TestCase("3.14", "-7.543", "*", "Result: -23.68502")]
        [TestCase("12.5", "4", "/", "Result: 3.125")]

        //Tests with exponential numbers
        [TestCase("1.5e53", "150", "*", "Result: 2.25e+55")]
        [TestCase("1.5e53", "150", "/", "Result: 1e+51")]

        //Test with invalid inputs
        [TestCase("", "3", "+", "Result: invalid input")]
        [TestCase("", "3", "-", "Result: invalid input")]
        [TestCase("", "3", "*", "Result: invalid input")]
        [TestCase("", "3", "/", "Result: invalid input")]
        [TestCase("5", "", "+", "Result: invalid input")]
        [TestCase("5", "", "-", "Result: invalid input")]
        [TestCase("5", "", "*", "Result: invalid input")]
        [TestCase("5", "", "/", "Result: invalid input")]
        [TestCase("abv", "10", "*", "Result: invalid input")]
        [TestCase("10", "abv", "*", "Result: invalid input")]
        [TestCase("abv", "abv", "*", "Result: invalid input")]

        //Test with invalid operations
        [TestCase("3", "7", "@", "Result: invalid operation")]
        [TestCase("3", "7", "", "Result: invalid operation")]
        [TestCase("3", "7", "!!!!", "Result: invalid operation")]

        //Test with Infinity
        [TestCase("Infinity", "7", "+", "Result: Infinity")]
        [TestCase("Infinity", "7", "-", "Result: Infinity")]
        [TestCase("Infinity", "7", "*", "Result: Infinity")]
        [TestCase("Infinity", "7", "/", "Result: Infinity")]
        [TestCase("7", "Infinity", "+", "Result: Infinity")]
        [TestCase("7", "Infinity", "-", "Result: -Infinity")]
        [TestCase("7", "Infinity", "*", "Result: Infinity")]
        [TestCase("7", "Infinity", "/", "Result: 0")]
        [TestCase("Infinity", "Infinity", "+", "Result: Infinity")]
        [TestCase("Infinity", "Infinity", "-", "Result: invalid calculation")]
        [TestCase("Infinity", "Infinity", "*", "Result: Infinity")]
        [TestCase("Infinity", "Infinity", "/", "Result: invalid calculation")]



        public void Test_Calculator(string num1, string num2, string operat, string result)
        {
            //Arange
            var field1 = driver.FindElement(By.Id("number1"));
            var field2 = driver.FindElement(By.Id("number2"));
            var operation = driver.FindElement(By.Id("operation"));
            var calculate = driver.FindElement(By.Id("calcButton"));
            var resultField = driver.FindElement(By.Id("result"));
            var clearField = driver.FindElement(By.Id("resetButton"));

            //Act

            field1.SendKeys(num1);
            operation.SendKeys(operat);
            field2.SendKeys(num2);
            calculate.Click();


            Assert.That(result, Is.EqualTo(resultField.Text));


            clearField.Click();
        }
    }
}