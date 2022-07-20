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
