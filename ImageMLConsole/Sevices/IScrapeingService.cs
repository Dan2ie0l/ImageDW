using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMLConsole.Sevices
{
    public interface IScrapeingService
    {
        Task<string[]> GetPages(string url, string category,IWebDriver driver);
        Task<string[]> Scrolling(IWebDriver driver);
        Task<string[]> GetLinks(IWebDriver driver, List<string> links);
        Task<string[]> Cleaning();
        Task<string[]> Download(string category,List<string> links);

    }
}
