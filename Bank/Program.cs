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

            SavingsAccount savingsAccount = new SavingsAccount("9400000001", "Karol", "Aksamski", 0.0M, 95030112230); //Pierwsze konto oszczędnościowe

            SavingsAccount savingsAccount2 = new SavingsAccount("9400000002", "Michał", "Aksiński", 0.0M, 98030115230); //Drugie konto oszczędnościowe

            BillingAccount billingAccount = new BillingAccount("9400000003", savingsAccount.FirstName, savingsAccount.LastName, 0.0M, savingsAccount.PeselNumber); //Pierwsze konto rozrachunkowe

            Printer printer = new Printer();

            printer.Print(savingsAccount);
            printer.Print(savingsAccount2);

            printer.Print(billingAccount);

            Console.ReadKey();
        }
    }
}
