using ImageMLConsole.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMLConsole.Sevices
{
    public class ApplicationStartupService
    {
        private IScrapeingService scrapeingService { get; set; }
        private IMediator mediator { get; set; }
        public  ApplicationStartupService(IScrapeingService scrapeingService, IMediator mediator)
        {
            this.scrapeingService = scrapeingService??throw new ArgumentNullException(nameof(scrapeingService));
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); 
        }
        public async Task Start()
        {
            Console.WriteLine("Test");
            var result= await mediator.Send(new GetPagesCommand() { 
                 URL= "https://www.pinterest.com/search/pins/?q="
            });
          //var result1 = await scrapeingService.GetPages("https://www.pinterest.com/search/pins/?q=");
        }
    }
}
