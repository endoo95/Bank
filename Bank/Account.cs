using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    abstract class Account //Klasa abstrakcyjna 
    {
        public int Id { get; }
        public string AccountNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public decimal Balance { get; }
        public long PeselNumber { get; }
        public Account(int id, string firstName, string lastName, long peselNumber)
        {
            Id = id;
            AccountNumber = GenerateAccountNumber(id);
            FirstName = firstName;
            LastName = lastName;
            Balance = 0.0M;
            PeselNumber = peselNumber;
        }

        public abstract string TypeName(); //Metoda abstrakcyjna
 

        public string GetFullName()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public string GetBalance()
        {
            return string.Format("{0}", Balance);
        }

        private string GenerateAccountNumber(int id)
        {
            var accountNumber = string.Format("94{0:D10}", id);
            return accountNumber;
        }
    }
}
