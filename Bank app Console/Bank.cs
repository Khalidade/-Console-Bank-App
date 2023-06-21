using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app_Console
{
    public class Bank
    {
        private List<Account> Accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            if (Accounts.Contains(account))
            {
                throw new Exception("Account already exists");
            }

            if(Accounts.Any(a => a.AccountType == account.AccountType && a.FirstName == account.FirstName && a.LastName == account.LastName))
            {
                throw new Exception("user cannot have the same account type");
            }
            Accounts.Add(account);

        }

        public void RemoveAccount(int accountNumber) 
        {
            Accounts.RemoveAll(a  => a.AccountNumber == accountNumber);
        }

        public Account GetAccount(int accountNumber)
        {
            return Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
        }

        public List<Account> GetAllAccounts()
        {
            return Accounts;
        }
        public void Deposit(int accountNumber, decimal amount)
        {
            Account account = GetAccount(accountNumber);
            account.AddMoney(amount);
        }

        public void withdraw(int accountNumber, decimal amount)
        {
            Account account = GetAccount(accountNumber);
            if(account.AccountType == "savings" && account.Balance - amount < 1000m)
            {
                throw new Exception("insuffficiant funds");
            }
            account.RemoveMoney(amount);
        }

        public void mulTransfer(int fromAccountNumber,int toAccountNumber, decimal amount)
        {
            Account fromAccount = GetAccount(fromAccountNumber);
            Account toAccount = GetAccount(toAccountNumber);
            fromAccount.RemoveMoney(amount);
            toAccount.AddMoney(amount);
        }

        public void PrintAccount()
        {
            Console.WriteLine("|---------------|----------------|--------------|-------------|---------|");
            Console.WriteLine("| FULL NAME     | ACCOUNT NUMBER | ACCOUNT TYPE | ACCOUNT BAL | NOTE    |");
            Console.WriteLine("|---------------|----------------|--------------|-------------|---------|");
            foreach (var account in Accounts) 
            {
                Console.WriteLine($"| {account.FirstName + " " + account.LastName})     |    {account.AccountNumber}   |   {account.AccountType}    | {account.Balance}    |   {account.Note}     |");


            }
            Console.WriteLine("|---------------|----------------|--------------|-------------|---------|");
        }

        
    }
}
