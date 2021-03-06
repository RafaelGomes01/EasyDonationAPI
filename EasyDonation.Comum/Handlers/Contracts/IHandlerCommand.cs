using EasyDonation.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDonation.Comum.Handlers.Contracts
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
