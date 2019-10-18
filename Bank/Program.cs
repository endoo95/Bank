using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Bank AKA";
            string author = "Karol Aksamski";

            Console.WriteLine(name);
            Console.WriteLine("Autor: " + author);

            SavingsAccount savingsAccount = new SavingsAccount(1, "Karol", "Aksamski", 95030112230); //Pierwsze konto oszczędnościowe
            SavingsAccount savingsAccount1 = new SavingsAccount(2, "Michał", "Aksiński", 98030115230); //Drugie konto oszczędnościowe
            BillingAccount billingAccount = new BillingAccount(3, savingsAccount.FirstName, savingsAccount.LastName, savingsAccount.PeselNumber); //Pierwsze konto rozrachunkowe


            Printer printer = new Printer();

            string fullName = savingsAccount.GetFullName();
            Console.WriteLine();
            Console.WriteLine("Pierwsze konto oszczędnościowe w systemie dostał(-a): {0}", fullName);
            printer.Print(savingsAccount);
            printer.Print(savingsAccount1);

            string fullName2 = billingAccount.GetFullName();
            Console.WriteLine();
            Console.WriteLine("Pierwsze konto rozliczeniowe w systemie dostał(-a): {0}", fullName);
            printer.Print(billingAccount);
            string accountBalance2 = billingAccount.GetBalance();
            Console.WriteLine();
            Console.WriteLine("Saldo konta wynosi: {0}", accountBalance2);

            Console.ReadKey();
        }
    }
}
