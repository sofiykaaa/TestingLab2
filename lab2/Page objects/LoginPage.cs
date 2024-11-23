using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    public void ClickLogin()
    {
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@type='submit' and @value='Login']")));
        loginButton.Click();
        Thread.Sleep(2000);
    }

    public void EnterUsername(string username)
    {
        IWebElement usernameInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//input[@type='text' and @name='user-name']")));
        usernameInput.SendKeys(username);
    }
    public void EnterPassword(string password)
    {
        IWebElement passwordInput = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//input[@type='password' and @name='password']")));
        passwordInput.SendKeys(password);
    }

    public string ShowErrorMSg()
    {
        IWebElement errorMSG = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//h3[@data-test='error']")));

        return errorMSG.Text;
    }

    public void CloseDriver()
    {
        driver.Quit();
    }

}
