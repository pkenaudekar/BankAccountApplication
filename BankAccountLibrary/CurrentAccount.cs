using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLibrary
{
    public class CurrentAccount : BankAccount
    {
        private int _transactionCount;
        private static int _maxTransactions;
        private static double _transactionFee;
        

        static CurrentAccount()
        {
            _transactionFee = 5.0;
            _maxTransactions = 5;
        }

        public CurrentAccount(string depositorName, double initialDeposit) : base(depositorName, initialDeposit, AccountType.Current)
        {

        }

        public override void Deposit(double amount)
        {
            _transactionCount += 1;
            base.Deposit(amount);
        }

        public override void Withdraw(double amount)
        {
            _transactionCount += 1;
            base.Withdraw(amount);
        }

        public void DeductFee()
        {
            if(_transactionCount > _maxTransactions)
            {
                double fees = (_transactionCount - _maxTransactions) * _transactionFee;
                base.Withdraw(fees);
                _transactionCount = 0;
            }
        }
    }
}
