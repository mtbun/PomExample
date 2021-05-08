using OpenQA.Selenium;

namespace Test.Pages
{
	public class LoginPage
	{
		private IWebDriver browser;
		public LoginPage(IWebDriver driver)
		{
			browser = driver;
		}

		IWebElement txtUsername => browser.FindElement(By.Name("kullanici"));
		IWebElement txtPassword => browser.FindElement(By.Name("sifre"));
		IWebElement btnLogin => browser.FindElement(By.Id("gg-login-enter"));

		public void EnterUsrAndPsw(string username, string password)
		{
			txtUsername.SendKeys(username);
			txtPassword.SendKeys(password);
		}

		public void ClickLogin()
		{
			btnLogin.Click();
		}


	}

}

