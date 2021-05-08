using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Test.Pages
{
	public class HomePage
	{
		private IWebDriver browser;

		public HomePage(IWebDriver driver)
		{
			browser = driver;
		}

		IWebElement BtnProfileIcon => browser.FindElement(By.XPath("//div[@title='Giriş Yap']"));
		IWebElement BtnSignin => browser.FindElement(By.XPath("//a[contains(@class,'qjixn8-0 sc-1bydi5r-0')]"));
		IWebElement SearchArea => browser.FindElement(By.TagName("input"));
		IWebElement Bul => browser.FindElement(By.XPath("//span[text()='BUL']"));
		IWebElement SecondPage => browser.FindElement(By.XPath("//a[@href='/arama/?k=bilgisayar&sf=2']"));
		IWebElement AnyProduct => browser.FindElement(By.XPath("//li[@product-id='576242108']"));
		IWebElement SelectProduct => browser.FindElement(By.XPath("//button[@product-id='576242108']"));

		public void Click(IWebElement btn)
		{
			WebDriverWait wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
			btn.Click();
		}

		public void Hover(IWebElement btn)
		{
			Actions action = new Actions(browser);
			action.MoveToElement(btn).Build().Perform();
		}

		public void HoverLogin()
		{
			Hover(BtnProfileIcon);
			Thread.Sleep(1000);
		}

		public void ClickSigninButton()
		{
			Click(BtnSignin);
		}

		public void Search(string arama)
		{
			SearchArea.SendKeys(arama);
		}

		public void ClickSearchButton()
		{
			Click(Bul);
		}

		

		

	}
}
