using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAccountLibrary;


namespace BankConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            BankAccount a1 = new BankAccount("John", 5000);
            
            BankAccount a2 = new BankAccount("Tom", 9600, AccountType.Current);

            //a2.Depositor = "Max";

            Console.WriteLine("Enter Your name");
            string name = Console.ReadLine();
            /*
            Console.WriteLine("Enter Your Account Number");
            int accountNumber = int.Parse(Console.ReadLine());*/

            Console.WriteLine("Enter Your Account Type (Savings/Current)");
            AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), (Console.ReadLine()));

            
            if (accountType == AccountType.Savings)
            {
                //BankAccount a3 = new BankAccount(name, 0, accountType, accountNumber);
                SavingAccount a3 = new SavingAccount(name, 0);
                Menu(a3);
            }
            else
            {
                CurrentAccount a3 = new CurrentAccount(name, 0);
                Menu(a3);
            }
        
        }

        static void Menu(BankAccount a3)
        {
            int choice;
            double amount;
            while (true)
            {
                if (a3.AccountType == AccountType.Savings)
                {
                    Console.WriteLine("\nSelect an option \n1 - Deposit \n2 - Withdrawal \n3 - Add Intrest \n4 - Details \n5 - Exit");
                }
                else 
                {
                    Console.WriteLine("\nSelect an option \n1 - Deposit \n2 - Withdrawal \n3 - Deduct Fees \n4 - Details \n5 - Exit ");
                }
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the amount to be deposited in your account");
                            amount = double.Parse(Console.ReadLine());
                            a3.Deposit(amount);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the amount to be withdraw from your account");
                            amount = double.Parse(Console.ReadLine());
                            a3.Withdraw(amount);
                            break;
                        }                    
                    case 3:
                        {
                            if (a3.AccountType == AccountType.Savings)
                            {
                                Console.WriteLine("Intrest added sussessfully");
                                SavingAccount a4 = (SavingAccount)a3;
                                a4.AddInterest();
                            }
                            else
                            {
                                Console.WriteLine("Fee deducted sussessfully");
                                CurrentAccount a4 = (CurrentAccount)a3;
                                a4.DeductFee();
                            }                               
                            break;
                        }
                    case 4:
                        {
                            a3.Display();
                            break;
                        }
                    case 5:
                        {
                            System.Environment.Exit(1);
                            break;
                        }
                }
            }
        }
    }
}
