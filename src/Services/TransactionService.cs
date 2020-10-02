using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Aws.Entities;
using Demo.Aws.Services.Interfaces;

//Create One Instance per request , it is not thread safe
namespace Demo.Aws.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAsyncRepository<Transaction> TransactionRepository;

        public TransactionService(IAsyncRepository<Transaction> transactionRepository)
        {
            TransactionRepository = transactionRepository;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            
            return await TransactionRepository.AddAsync(transaction);
        }      

        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await TransactionRepository.ListAllAsync();
        }
       
    }
}