using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMLConsole.Sevices
{
    public class ScrapingService : IScrapeingService
    {
        public async Task<string[]> GetLinks(string url)
        {
            Console.WriteLine("Get Link");
            return null;
        }

        public async Task<string[]> GetPages(string url)
        {
            Console.WriteLine("Get Link");
            return null;
        }
    }
}
