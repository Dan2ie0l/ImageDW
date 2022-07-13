using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMLConsole.Sevices
{
    public class ScrapingService : IScrapeingService
    {

        private readonly IWebDriver? driver;
        private readonly string path;
        private readonly string url = "https://www.pinterest.com/search/pins/?q=";

        private readonly string[] categories = { "car", "house", "phone", "Mazda" };
        public ScrapingService()
        {
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
        }
        public async Task<string[]> GetLinks(string url)
        {
            Console.WriteLine("Get Link");
            return null;
        }

        public async Task<string[]> GetPages(string url)
        {
            Console.WriteLine("Get Pages");

            driver.Navigate().GoToUrl(url + categories[0]);
            driver.Manage().Window.Maximize();

            return null;
        }
    }
}
