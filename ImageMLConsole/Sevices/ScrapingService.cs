using ImageMLConsole.CommandHandler;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace ImageMLConsole.Sevices
{
    public class ScrapingService : IScrapeingService
    {
        public List<string> linkswithoutdub = new List<string>();
        int n = 0;

   /*     public static List<string> link1 = new List<string>();
        public static List<string> link2 = new List<string>();
        public static List<string> link3 = new List<string>();
        public static List<string> link4 = new List<string>();
        public static List<string> link5 = new List<string>();
        public static List<string> link6 = new List<string>();
        public static List<string> link7 = new List<string>();
        public static List<string> link8 = new List<string>();
        public static List<string> link9 = new List<string>();
        public static List<string> link10 = new List<string>();*/

        public static ChromeOptions chrome_options = new ChromeOptions();
        public static readonly string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

       /* public static IWebDriver driver1;
        public static IWebDriver driver2;
        public static IWebDriver driver3;
        public static IWebDriver driver4;
        public static IWebDriver driver5;
        public static IWebDriver driver6;
        public static IWebDriver driver7;
        public static IWebDriver driver8;
        public static IWebDriver driver9;
        public static IWebDriver driver10;*/

        private readonly string url = "https://www.pinterest.com/search/pins/?q=";

        public ScrapingService()
        {
           
            chrome_options.BinaryLocation = "C:/Program Files/Google/Chrome Beta/Application/chrome.exe";
            chrome_options.AddArguments(new List<string>() {
    "--silent-launch",
    "--no-startup-window",
    "no-sandbox",
    "headless",});
          /*  driver1 = new ChromeDriver(path + @"\drivers\", chrome_options);
            driver2 = new ChromeDriver(path + @"\drivers\", chrome_options);
            driver3 = new ChromeDriver(path + @"\drivers\", chrome_options);
            driver4 = new ChromeDriver(path + @"\drivers\", chrome_options);
            driver5 = new ChromeDriver(path + @"\drivers\", chrome_options);*/

        }
        public async Task<string[]> GetLinks(string url)
        {
            Console.WriteLine("Get Link");
            return null;
        }

        public async Task<string[]> GetPages(string url, string category, IWebDriver driver)
        {
            Console.WriteLine("Get Pages");

            driver.Navigate().GoToUrl(url + category);

            return null;
        }

        public async Task<string[]> Scrolling(IWebDriver driver)
        {

            IJavaScriptExecutor js = driver as IJavaScriptExecutor;

            Thread.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0,900);");



            return null;
        }

        public string randomNames()
        {
            int length = 7;
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            string name = str_build.ToString();

            return name;
        }

        public async Task<string[]> GetLinks(IWebDriver driver, List<string> links)
        {

            bool staleElement = true;

            while (staleElement)
            {

                try
                {

                    IReadOnlyList<IWebElement> list = driver.FindElements(By.CssSelector("img.hCL.kVc.L4E.MIw"));

                    foreach (IWebElement element in list)
                    {
                        links.Add(element.GetAttribute("src"));
                    }

                    staleElement = false;


                }
                catch (StaleElementReferenceException e)
                {

                    staleElement = true;
                    Console.WriteLine(e.Message);

                }
                continue;
            }

            return null;
        }

        public async Task<string[]> Download(string category, List<string> links)
        {



            string root = "C:\\" + category;
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            linkswithoutdub = links.Distinct().ToList();


            Console.WriteLine();
            Console.WriteLine(links.Count);
            Console.WriteLine(linkswithoutdub.Count);
            WebClient downloader = new WebClient();

            foreach (string src in linkswithoutdub)
            {
                downloader.DownloadFile(src, root + "\\" + randomNames() + ".jpg");
                n++;
            }

            Console.WriteLine(n);



            return null;


        }

        public async Task<string[]> Cleaning()
        {
            n = 0;
            linkswithoutdub.Clear();



            return null;
        }

       
    }
}

