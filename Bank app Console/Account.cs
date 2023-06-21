using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app_Console
{
    public class Account
    {
        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$",ErrorMessage = "use Upper Digit for First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$", ErrorMessage ="use upper Digit for last name ")]
        public string LastName { get; set; }

        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string Note { get; set; }
        public decimal Balance { get; set; }

        public Account(string firstName, string lastName, int accountNumber, string accountType, string note, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
            AccountType = accountType;
            Note = note;
            Balance = balance;
        }

        public void AddMoney(decimal amount)
        {
            Balance += amount;
        }

        public void RemoveMoney(decimal amount)
        {
            if(AccountType == "savings" && Balance - amount < 1000m)
            {
                throw new Exception("insufficient funds");
            }
            Balance -= amount;
        }

        public void Transfer(decimal amount, Account otherAccount)
        {
            RemoveMoney(amount);
            otherAccount.AddMoney(amount);


        }

        public override string ToString()
        {
            return $"Account {AccountNumber}: {FirstName} {LastName}({AccountType}) - Balance: {Balance}";
        }


    }
}
