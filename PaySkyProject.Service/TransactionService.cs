using paysky.Data;
using paysky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paysky.Service
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransaction(int id);
        void CreateTransaction(Transaction Transaction);
        void SaveTransaction();
    }

    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository TransactionsRepository;
        private readonly IUnitOfWork unitOfWork;

        public TransactionService(ITransactionRepository TransactionsRepository, IUnitOfWork unitOfWork)
        {
            this.TransactionsRepository = TransactionsRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ITransactionService Members

        public IEnumerable<Transaction> GetTransactions()
        {
            var Transactions = TransactionsRepository.GetAll();
            return Transactions;
        }

        public Transaction GetTransaction(int id)
        {
            var Transaction = TransactionsRepository.GetById(id);
            return Transaction;
        }

        public void CreateTransaction(Transaction transaction)
        {
            this.ValidateTransationObject(transaction);
            TransactionsRepository.Add(transaction);
        }

        public void SaveTransaction()
        {
            unitOfWork.Commit();
        }

        void ValidateTransationObject(Transaction transaction)
        {
            if (transaction == null)
                throw new ArgumentNullException();

            var validator = new TransactionValidation();
            var results = validator.Validate(transaction);

            if (!results.IsValid)
                throw new ArgumentException();
        }

        #endregion

    }
    
}
