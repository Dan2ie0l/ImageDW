using ImageMLConsole.Command;
using ImageMLConsole.Sevices;
using MediatR;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ImageMLConsole.CommandHandler
{
    public class GetPagesCommandHandler : IRequestHandler<GetPagesCommand, string[]>
    {
        public static readonly string[] categories = { "girls", "house", "animals", "ocean", "drawing","fauna","flora","marvel","cigarettes","earthquake"};
        private IScrapeingService scrapeingService { get; set; }
       

        public GetPagesCommandHandler(IScrapeingService scrapeingService)
        {
            this.scrapeingService = scrapeingService;
        }
        public async Task<string[]> Handle(GetPagesCommand request, CancellationToken cancellationToken)
        {
            List<Thread> ths = new List<Thread>();
            foreach(string category in categories)
            {
                List<string> links = new List<string>();
                IWebDriver driver = new ChromeDriver(ScrapingService.path + @"\drivers\", ScrapingService.chrome_options);
                Thread th = new Thread(() => m_threading(request, category,driver, links));
                th.Start();
            }
              

            /*Thread first = new Thread(() => m_threading(request, categories[0], ScrapingService.driver1, ScrapingService.link1));
            Thread second = new Thread(() => m_threading(request, categories[1], ScrapingService.driver2, ScrapingService.link2));
            Thread third = new Thread(() => m_threading(request, categories[2], ScrapingService.driver3, ScrapingService.link3));
            Thread fourth = new Thread(() => m_threading(request, categories[3], ScrapingService.driver4, ScrapingService.link4));
            Thread fifth = new Thread(() => m_threading(request, categories[4], ScrapingService.driver5, ScrapingService.link5));


            first.Start();
            second.Start();
            third.Start();
            fourth.Start();
            fifth.Start();
            first.Join();
            second.Join();
            third.Join();
            fourth.Join();
            fifth.Join();




            if (!first.IsAlive && !second.IsAlive && !third.IsAlive && !fourth.IsAlive && !fifth.IsAlive)
            {

                ScrapingService.driver1.Dispose();
                ScrapingService.driver2.Dispose();
                ScrapingService.driver3.Dispose();
                ScrapingService.driver4.Dispose();
                ScrapingService.driver5.Dispose();

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("2nd part");
                ScrapingService.chrome_options.BinaryLocation = "C:/Program Files/Google/Chrome Beta/Application/chrome.exe";
                ScrapingService.driver6 = new ChromeDriver(ScrapingService.path + @"\drivers\", ScrapingService.chrome_options);
                ScrapingService.driver7 = new ChromeDriver(ScrapingService.path + @"\drivers\", ScrapingService.chrome_options);
                ScrapingService.driver8 = new ChromeDriver(ScrapingService.path + @"\drivers\", ScrapingService.chrome_options);
                ScrapingService.driver9 = new ChromeDriver(ScrapingService.path + @"\drivers\", ScrapingService.chrome_options);
                ScrapingService.driver10 = new ChromeDriver(ScrapingService.path + @"\drivers\", ScrapingService.chrome_options);

                Thread sixth = new Thread(() => m_threading(request, categories[5], ScrapingService.driver6, ScrapingService.link6));
                Thread seventh = new Thread(() => m_threading(request, categories[6], ScrapingService.driver7, ScrapingService.link7));
                Thread eighth = new Thread(() => m_threading(request, categories[7], ScrapingService.driver8, ScrapingService.link8));
                Thread ninth = new Thread(() => m_threading(request, categories[8], ScrapingService.driver9, ScrapingService.link9));
                Thread tenth = new Thread(() => m_threading(request, categories[9], ScrapingService.driver10, ScrapingService.link10));

                sixth.Start();
                seventh.Start();
                eighth.Start();
                ninth.Start();
                tenth.Start();
                sixth.Join();
                seventh.Join();
                eighth.Join();
                ninth.Join();
                tenth.Join();

                ScrapingService.driver6.Dispose();
                ScrapingService.driver7.Dispose();
                ScrapingService.driver8.Dispose();
                ScrapingService.driver9.Dispose();
                ScrapingService.driver10.Dispose();

            }

*/


            return new string[] { };
        }

        public async Task m_threading(GetPagesCommand request, string category, IWebDriver driver, List<string> links)
        {
            Console.WriteLine(request.URL);
            await this.scrapeingService.GetPages(request.URL, category, driver);


            for (int i = 0; i < 80; i++)
            {
                await this.scrapeingService.GetLinks(driver, links);
                await this.scrapeingService.Scrolling(driver);
            }


            await this.scrapeingService.Download(category, links);

            await this.scrapeingService.Cleaning();

           




        }
    }
}
