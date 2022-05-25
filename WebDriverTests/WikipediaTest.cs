using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


//Create new Chrome Browser Instance
var driver = new ChromeDriver();

// Navigate to wikipedia
driver.Url = "https://wikipedia.org";

System.Console.WriteLine("CURRENT TITLE: " + driver.Title);

//locate search field by ID
var searchField = driver.FindElement(By.Id("searchInput"));

//click on element
searchField.Click();

//fill QA and press ENTER keyboard button
searchField.SendKeys("QA" + Keys.Enter);
//searchField.SendKeys(Keys.Enter);

System.Console.WriteLine("TITLE AFTER SERCH: " + driver.Title);


//Close browser
driver.Quit();

