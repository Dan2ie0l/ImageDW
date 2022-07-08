using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMLConsole.Command
{
    public class GetPagesCommand : IRequest<string[]>
    {
        public string URL { get; set; }
    }
}
