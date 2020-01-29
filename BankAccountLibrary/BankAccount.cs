using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountLibrary
{

  public class BankAccount
    {
        private int _accountNumber;
        private string _depositorName;
        protected double _balance;
        private AccountType _accountType;

        private static int _cuurentAccountNumber;

      

        // Default Constructor
        public BankAccount()
        {
            _accountNumber = ++_cuurentAccountNumber;
        }

        //Parameterized Constructor
        //Calling a constructor from within a constructor
        public BankAccount(string depositorName, double initialDeposit) : this(depositorName, initialDeposit, AccountType.Savings)
        {
            //this._depositorName = depositorName;
            //this._balance = initialDeposit;
            //this._accountType = AccountType.Savings;
            //_accountNumber = ++_cuurentAccountNumber;
        }

        //Parameterized Constructor
        public BankAccount(string depositorName, double initialDeposit, AccountType accountType)
        {
            this._depositorName = depositorName;
            this._balance = initialDeposit;
            this._accountType = accountType;
            _accountNumber = ++_cuurentAccountNumber;
        }

        //Parameterized Constructor

        /*public BankAccount(string depositorName, double initialDeposit, AccountType accountType, int accountNumber)
        
        {
            this._depositorName = depositorName;
            this._balance = initialDeposit;
            this._accountType = accountType;
            //this._accountNumber = accountNumber;
            _accountNumber = ++_cuurentAccountNumber;
        }
        */


        //Methods
        public virtual void Deposit(double amount)
        {           
            this._balance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= this._balance)
            {
                this._balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void Transfer(BankAccount personBAccount, double amount)
        {
            if (amount <= this._balance)
            {
                this._balance -= amount;
                this.Transfer(personBAccount, amount);
                
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }

        }

        public void Display()
        {
            Console.WriteLine("Account Number: {0}\nDepositor Name: {1}\nBalance: {2} \nAccount Type: {3}",_accountNumber,_depositorName,_balance,_accountType);
        }

        public string Depositor
        {
            get
            {
                return _depositorName;
            }

            set
            {
                _depositorName = value;
            }
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
        }

        public AccountType AccountType
        {
            get
            {
                return _accountType;
            }

            set
            {
                _accountType = value;
            }
        }

        public double AccountNumber
        {
            get
            {
                return _accountNumber;
            }
        }
    }    
}
