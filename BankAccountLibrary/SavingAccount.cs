using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLibrary
{
    public sealed class SavingAccount : BankAccount
    {
        private double _interestEarned;
        private static double _interestRate;

        //Static constructor used for initialising static menmers of a class
        static SavingAccount()
        { 
            _interestRate = 4.0; 
        }

        //derived class constructor getting and passing values to base class
        public SavingAccount(string depositorName, double initialDeposit):base(depositorName,initialDeposit)
        {

        }
        public double InterestEarned
        {
            get
            {
                return _interestEarned;
            }
           
        }

        public double InterestRate
        {
            get
            {
                return _interestRate;
            }
            set
            {
                _interestRate = value;
            }

        }

        public void AddInterest()
        {
            _interestEarned = (_balance * _interestRate) / 100.0;
            base.Deposit(_interestEarned);
        }
    }
}
