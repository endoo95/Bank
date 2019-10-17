using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class SavingsAccount
    {
        public string AccountNumber;
        public string FirstName;
        public string LastName;
        public decimal Balance;
        public long PeselNumber;

        public SavingsAccount(string accountNumber, string firstName, string lastName, decimal balance, long peselnumber)
        {
            AccountNumber = accountNumber;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
            PeselNumber = peselnumber;
        }
    }
}
