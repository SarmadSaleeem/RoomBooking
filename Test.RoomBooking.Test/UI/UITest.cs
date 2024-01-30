using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.DefaultWaitHelpers;

namespace NFS.RoomBooking.Test;

public class UiTest
{
    private readonly IConfiguration _configuration;
    private readonly OpenQA.Selenium.Chrome.ChromeDriver _webDriver;

    public UiTest()
    {
        _configuration = new ConfigurationBuilder().AddJsonFile("configuration.json").Build();
        _webDriver = new ChromeDriver(_configuration["DriverPath"]);
        
        if (Convert.ToBoolean(_configuration["MaxWindow"]))
            _webDriver.Manage().Window.Maximize();
        
        _webDriver.Navigate().GoToUrl(_configuration["WebSiteUrl"]);
    }
    
    [Fact]
    public void Login()
    {
        LoginTest(email:_configuration["Credentials:userName"], password:_configuration["Credentials:password"]);
        _webDriver.Quit();
    }

    [Fact]
    public void SendEmail()
    {
        LoginTest(email:_configuration["Credentials:userName"], password:_configuration["Credentials:password"]);
        SendEmailTest();
    }


    private void LoginTest(string? email, string? password)
    {
        IWebElement toSigninPageElement = _webDriver.FindElement(By.XPath("//a[@href='https://account.proton.me/login']"));
        toSigninPageElement.Click();

        IWebElement emailElement = _webDriver.WaitUntil(ExpectedConditionsSearchContext.ElementIsVisible(By.XPath("//input[@id='username']")));
        emailElement.SendKeys(email);

        IWebElement passwordElement = _webDriver.FindElement(By.Id("password"));
        passwordElement.Click();
        passwordElement.SendKeys(password);

        //If partial match => "[class^='button w-full button-large button-solid-norm']
        IWebElement signinElement = _webDriver.FindElement(By.CssSelector("button.w-full.button-large.button-solid-norm.mt-6"));
        signinElement.Click();

        IWebElement compostButton = _webDriver.WaitUntil(ExpectedConditionsSearchContext.ElementToBeClickable(
            By.XPath("//button[@data-testid='sidebar:compose']")));
        
        Assert.True(compostButton is not null);
    }

    private void SendEmailTest()
    {
        
        IWebElement composeEmailButton = _webDriver.FindElement(By.XPath("//button[@data-testid='sidebar:compose']"));
        composeEmailButton.Click();

        IWebElement receiverEmailElement = _webDriver.WaitUntil(
            ExpectedConditionsSearchContext.ElementIsVisible(By.XPath("//input[@data-testid='composer:to']")));
        receiverEmailElement.Click();
        receiverEmailElement.SendKeys(_configuration["ReceiverEmail"]);
        
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

        IWebElement notificationElement =
            _webDriver.WaitUntil(ExpectedConditionsSearchContext.ElementIsVisible(By.XPath("//span[@class='notification__content']")));

        _webDriver.WaitUntil(ExpectedConditionsSearchContext.TextToBePresentInElement(notificationElement, "Message sent."));

        Assert.Contains("Message sent.", notificationElement.Text);
        _webDriver.Quit();
    }
}