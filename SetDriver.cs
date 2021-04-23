using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;

public class SetDrive
{
	public IWebDriver  GetDriver(string Name)
	{
		IWebDriver driver;
		switch(Name)
		{
			case "Chrome":
				driver = new ChromeDriver();
				break;
			case "FireFox":
				driver = new FirefoxDriver();
				break;
			case "iexplorer":
				driver = new InternetExplorerDriver();
				break;
			default:
				driver = null;
				break;
		}
		return driver;
	}
}
