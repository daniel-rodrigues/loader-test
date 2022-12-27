using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loader.WorkerService.Consumers;

public interface IConsumerConfiguration
{
    string URL { get; }
    string Token { get; }
    string Header { get; }
}

