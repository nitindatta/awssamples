using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Aws.Entities;

namespace Demo.Aws.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactions();
        Task<Transaction> AddTransaction(string name);
 

    }
}