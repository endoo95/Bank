using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Printer
    {
        public void Print(SavingsAccount account)
        {
            Console.WriteLine(); //Wypisanie danych konta
            Console.WriteLine("Dane konta: {0}", account.AccountNumber);
            Console.WriteLine("Imię właściciela: {0}", account.FirstName);
            Console.WriteLine("Nazwisko właściciela: {0}", account.LastName);
            Console.WriteLine("Saldo konta: {0}", account.Balance + " PLN");
            Console.WriteLine("Numer Pesel: {0}", account.PeselNumber);
        }

        public void Print(BillingAccount account)
        {
            Console.WriteLine(); //Wypisanie danych konta
            Console.WriteLine("Dane konta: {0}", account.AccountNumber);
            Console.WriteLine("Imię właściciela: {0}", account.FirstName);
            Console.WriteLine("Nazwisko właściciela: {0}", account.LastName);
            Console.WriteLine("Saldo konta: {0}", account.Balance + " PLN");
            Console.WriteLine("Numer Pesel: {0}", account.PeselNumber);
        }
    }
}
