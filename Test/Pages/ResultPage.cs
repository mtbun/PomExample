using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Test.Pages
{
	public class ResultPage
	{
		private IWebDriver browser;
		public ResultPage(IWebDriver driver)
		{
			browser = driver;
		}

		IWebElement SecondPage => browser.FindElement(By.CssSelector("div#best-match-right>div:nth-of-type(5)>ul>li:nth-of-type(2)>a"));
		IWebElement AnyProduct => browser.FindElement(By.XPath("//li[@product-id='576115045']"));
		IWebElement ProductPrice => browser.FindElement(By.Id("sp-price-lowPrice"));
		IWebElement AddBasketBtn => browser.FindElement(By.Id("add-to-basket"));
		IWebElement Basket => browser.FindElement(By.PartialLinkText("Sepete Git"));
		IWebElement ProductPriceinBas => browser.FindElement(By.XPath("//div[@class='total-price']//strong"));
		//IWebElement AmountDropdown => browser.FindElement(By.ClassName("amount"));
		IWebElement DeleteItem => browser.FindElement(By.XPath("//i[@class='gg-icon gg-icon-bin-medium']"));
		IWebElement EmptyBasket => browser.FindElement(By.XPath("//h2[text()='Sepetinizde ürün bulunmamaktadır.']"));
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
		public void ScrollDown()
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)browser;
			js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
			Thread.Sleep(1000);
		}
		public void GoSecondPage()
		{
			Click(SecondPage);
		}

		public string TxtProductPrice()
		{
			string x = ProductPrice.Text;
			return x;
		}

		public void GoProduct()
		{
			Click(AnyProduct);
		}

		public void AddtoBasket()
		{
			Click(AddBasketBtn);
			Thread.Sleep(1000);

		}

		public void GotoBasket()
		{
			Click(Basket);
		}

		public string TxtProductPriceinBas()
		{
			string x = ProductPriceinBas.Text;
			return x;
		}

		/*public void ChangeAmount()
		{
			Click(AmountDropdown);
			SelectElement element = new SelectElement(AmountDropdown);
			element.SelectByIndex(2);
			Thread.Sleep(2000);
		}
		*/
		public void DeleteProduct()
		{
			Click(DeleteItem);
		}
		public bool AssertEmptyBasket()
		{
			string expecto = "Sepetinizde ürün bulunmamaktadır.";
			string actual = EmptyBasket.Text;

			if (expecto == actual)
			{
				return true;
			}
			return false;
		}

	}
}

