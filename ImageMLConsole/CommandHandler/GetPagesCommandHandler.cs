using ImageMLConsole.Command;
using ImageMLConsole.Sevices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMLConsole.CommandHandler
{
    public class GetPagesCommandHandler : IRequestHandler<GetPagesCommand, string[]>
    {
        private IScrapeingService scrapeingService { get; set; }

        public GetPagesCommandHandler(IScrapeingService scrapeingService)
        {
            this.scrapeingService = scrapeingService;
        }
        public async Task<string[]> Handle(GetPagesCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.URL);
            await this.scrapeingService.GetPages("test");
            return new string[] { };
        }
    }
}
