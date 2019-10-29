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

            BankManager bankManager = new BankManager();
            bankManager.Run();

            /* STARY PROGRAM

            //Stworzenie nowego managera kont
            AccountsManager manager = new AccountsManager();

            //Dodanie pierwszych kont użytkowników
            manager.CreateSavingsAccount("Karol", "Aksamski", 95030112230);
            manager.CreateSavingsAccount("Kamil", "Glinkowski", 92030212250);
            manager.CreateBillingAccount("Karol", "Aksamski", 95030112230);
            manager.CreateSavingsAccount("Kamil", "Podejrzany", 98472352230);

            //Zebranie listy wszystkich kont
            IList<Account> accounts = (IList<Account>)manager.GetAllAccounts();

            //Wypisanie ilości kont
            Console.WriteLine("Liczba kont w systemie: {0}", accounts.Count);
            Console.WriteLine();

            //Deklaracja drukarki i wypisanie kont przykłądowych
            IPrinter printer = new Printer();

            foreach (Account account in accounts)
            {
                printer.Print(account);
            }

            //Wypisanie kont w systemie w formacie: Imię | Nazwisko | PESEL
            Console.WriteLine("Konta w systemie posiadają:");
            IEnumerable<string> users = manager.ListOfCustomers();

            foreach(string user in users)
            {
                Console.WriteLine(user);
            }

            //Oczekiwanie na ruch użytkownika
            Console.ReadKey();

            */
        }
    }
}
