using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyFramework.Core.CrossCuttingConcerns.Transaction
{
    //contrallara kalıtım verebiliriz 
    public class ManagerBase
    {
        public void ExecuteTransactionalOperation(Action codetoExecute)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    codetoExecute();
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
