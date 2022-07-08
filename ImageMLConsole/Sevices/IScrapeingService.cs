using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMLConsole.Sevices
{
    public interface IScrapeingService
    {
        Task<string[]> GetPages(string url);
        Task<string[]> GetLinks(string url);
    }
}
