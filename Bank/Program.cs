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
            Console.WriteLine();
            Console.WriteLine("---");
            Console.WriteLine();

            AccountsManager manager = new AccountsManager();

            manager.CreateSavingsAccount("Karol", "Aksamski", 95030112230);
            manager.CreateSavingsAccount("Kamil", "Glinkowski", 92030212250);
            manager.CreateBillingAccount("Karol", "Aksamski", 95030112230);
            manager.CreateSavingsAccount("Kamil", "Podejrzany", 98472352230);

            IList<Account> accounts = (IList<Account>)manager.GetAllAccounts();

            IPrinter printer = new Printer();

            printer.Print(accounts[1]);
            printer.Print(accounts[3]);

            Console.ReadKey();
        }
    }
}
