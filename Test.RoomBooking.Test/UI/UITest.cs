using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.DefaultWaitHelpers;

namespace NFS.RoomBooking.Test;

public class UITest : IAsyncLifetime
{
    private readonly IWebDriver _webDriver = new ChromeDriver("c:\\Drivers");

    [Fact]
    public void Login()
    {
        IWebElement toSigninPageElement = _webDriver.FindElement(By.XPath("//a[@href='https://account.proton.me/login']"));
        toSigninPageElement.Click();

        WebDriverWait driverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

        IWebElement emailElement = driverWait.Until(ExpectedConditionsSearchContext.ElementIsVisible(By.XPath("//input[@id='username']")));
        emailElement.SendKeys("Alina123659878");

        IWebElement passwordElement = _webDriver.FindElement(By.Id("password"));
        passwordElement.Click();
        passwordElement.SendKeys("asd@12345");

        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        //If partial match => "[class^='button w-full button-large button-solid-norm']
        IWebElement signinElement = _webDriver.FindElement(By.CssSelector("button.w-full.button-large.button-solid-norm.mt-6"));
        signinElement.Click();
        
        IWebElement composeEmailButton = _webDriver.FindElement(By.XPath("//button[@data-testid='sidebar:compose']"));
        
        Assert.True(composeEmailButton is not null);
    }

    [Fact]
    public void SendEmail()
    {
        IWebElement toSigninPageElement = _webDriver.FindElement(By.XPath("//a[@href='https://account.proton.me/login']"));
        toSigninPageElement.Click();
        
        WebDriverWait driverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
        
        IWebElement emailElement = driverWait.Until(ExpectedConditionsSearchContext.ElementIsVisible(By.XPath("//input[@id='username']")));
        emailElement.SendKeys("Alina123659878");
        
        IWebElement passwordElement = _webDriver.FindElement(By.Id("password"));
        passwordElement.Click();
        passwordElement.SendKeys("asd@12345");
        
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        
        //If partial match => "[class^='button w-full button-large button-solid-norm']
        IWebElement signinElement = _webDriver.FindElement(By.CssSelector("button.w-full.button-large.button-solid-norm.mt-6"));
        signinElement.Click();

        IWebElement composeEmailButton = _webDriver.FindElement(By.XPath("//button[@data-testid='sidebar:compose']"));
        composeEmailButton.Click();
        
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        IWebElement receiverEmailElement = _webDriver.FindElement(By.XPath("//input[@data-testid='composer:to']"));
        receiverEmailElement.Click();
        receiverEmailElement.SendKeys("sarmadawan81@gmail.com;");
        
        IWebElement subjectElement = _webDriver.FindElement(By.XPath("//input[@data-testid='composer:subject']"));
        subjectElement.Click();
        subjectElement.SendKeys("Test Email");

        IWebElement iframe = _webDriver.FindElement(By.XPath("//iframe[@data-testid='rooster-iframe']"));
        _webDriver.SwitchTo().Frame(iframe);
        
        IWebElement bodyElement = _webDriver.FindElement(By.XPath("//div[@id='rooster-editor']"));
        bodyElement.Click();
        bodyElement.Clear();
        bodyElement.SendKeys("This is a Test Email");
        _webDriver.SwitchTo().DefaultContent();

        IWebElement sendEmailButton = _webDriver.FindElement(By.XPath("//button[@data-testid='composer:send-button']"));
        sendEmailButton.Click();
        
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        IWebElement notificationElement = _webDriver.FindElement(By.XPath("//span[@class='notification__content']"));
        
        Assert.Contains("Sending message...", notificationElement.Text);

        _webDriver.Quit();
    }

    public Task InitializeAsync()
    {
        _webDriver.Manage().Window.Maximize();
        _webDriver.Navigate().GoToUrl("https://proton.me/");
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _webDriver.Quit();
        return Task.CompletedTask;
    }
}