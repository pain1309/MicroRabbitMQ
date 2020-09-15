using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;

namespace MicroRabbit.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
