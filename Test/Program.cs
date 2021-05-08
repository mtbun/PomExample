using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Test.Pages;
using System.Collections.Generic;

namespace Test
{
	class MainClass
	{
		static void Main() { }

		private IWebDriver browser;

		string username = "";
		string password = "";
		string query = "bilgisayar";
		string expectedTitle1 = "GittiGidiyor - Türkiye'nin Öncü Alışveriş Sitesi";
		string expectedTitle2 = "Bilgisayar - GittiGidiyor - 2";


		[SetUp]
		public void Initialize()
		{
			browser = new ChromeDriver();
			browser.Navigate().GoToUrl("https://www.gittigidiyor.com");
		}

		[Test]
		public void ExecuteTest()
		{

			HomePage homePage = new HomePage(browser);
			LoginPage loginPage = new LoginPage(browser);
			ResultPage resultPage = new ResultPage(browser);
			Assert.AreEqual(true, browser.Title.Contains(expectedTitle1), "Title 1 is not matching");

			homePage.HoverLogin();
			homePage.ClickSigninButton();
			loginPage.EnterUsrAndPsw(username, password);
			loginPage.ClickLogin();
			Assert.AreEqual(true, browser.Title.Contains(expectedTitle1), "Title 2 is not matching");
			
			homePage.Search(query);
			homePage.ClickSearchButton();

			resultPage.ScrollDown();
			resultPage.GoSecondPage();
			Assert.AreEqual(true, browser.Title.Contains(expectedTitle2), "Title 3 is not matching");

			resultPage.GoProduct();
			string ExpectedPrice = resultPage.TxtProductPrice();
			resultPage.ScrollDown();
			resultPage.AddtoBasket();
			resultPage.GotoBasket();
			string ActualPrice = resultPage.TxtProductPriceinBas();
			Assert.AreEqual(ExpectedPrice, ActualPrice);

			resultPage.DeleteProduct();
			Console.WriteLine(resultPage.AssertEmptyBasket());

		}

		[TearDown]
		public void CleanUp()
		{
			browser.Close();
		}
	}
}
 