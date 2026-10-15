
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using THappyFlowTest;
namespace SauceDemo.Tests;
[TestFixture]
public class HappyFlowTest
{


    private IWebDriver driver;
    private const string BaseUrl = "https://www.saucedemo.com/";


    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var options = new ChromeOptions();
        options.AddArgument("start-maximized");
        options.AddArgument("--guest");

        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

    }
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        driver?.Quit();
        driver?.Dispose();
    }
    [Test]
    public void happyFlow()
    {
        driver.Navigate().GoToUrl(BaseUrl);
        CustomMethods.EnterText(driver, By.Id("user-name"), "standard_user");

        CustomMethods.EnterText(driver, By.Id("password"), "secret_sauce");
        CustomMethods.Click(driver, By.Id("login-button"));
        CustomMethods.Click(driver, By.Id("add-to-cart-sauce-labs-backpack"));
        CustomMethods.Click(driver, By.Id("add-to-cart-sauce-labs-bike-light"));
        CustomMethods.Click(driver, By.Id("shopping_cart_container"));
        CustomMethods.Click(driver, By.Id("checkout"));
        CustomMethods.EnterText(driver, By.Id("first-name"), "Omar");
        CustomMethods.EnterText(driver, By.Id("last-name"), "Shahid");
        CustomMethods.EnterText(driver, By.Id("postal-code"), "12345");
        CustomMethods.Click(driver, By.Id("continue"));
        CustomMethods.Click(driver, By.Id("finish"));
        Assert.That(driver.FindElement(By.Id("generate-pdf-order")).Displayed, Is.True, "Order is not completed");

    }
}

