using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _ctx;
        public TransferRepository(TransferDbContext ctx)
        {
            this._ctx = ctx;
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLogs;
        }
        public void Add(TransferLog transferLog)
        {
            _ctx.TransferLogs.Add(transferLog);
            _ctx.SaveChanges();
        }
    }
}
