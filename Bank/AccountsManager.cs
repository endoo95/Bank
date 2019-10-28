using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class AccountsManager
    {
        //Tworzenie listy kont umożliwiającej zaawansowane funkcje jak dodawanie, czy usuwanie elementów
        private IList<Account> _accounts;

        public AccountsManager() 
        {
            _accounts = new List<Account>();
        }

        //Metoda tworzenia konta oszczędnościowego
        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long peselNumber)
        {
            int id = generateId();

            SavingsAccount account = new SavingsAccount(id, firstName, lastName, peselNumber);

            _accounts.Add(account);

            return account;
        }

        //Metoda tworzenia konta rozrachunkowego
        public BillingAccount CreateBillingAccount(string firstName, string lastName, long peselNumber)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, peselNumber);

            _accounts.Add(account);

            return account;
        }

        //Nowa lista z kontami do obsługi funkcji z managera związanymi z przechodzeniem przez elementy listy
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

        //Generowanie numeru ID konta
        private int generateId()
        {
            int id = 1;

            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }

            return id;
        }

        //Wybranie kont jednego klienta

        /* STARA FUNKCJA (bez użycia Linq)
        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel)
        {
            List<Account> customerAccounts = new List<Account>();

            foreach (Account account in _accounts)
            {
                if (account.FirstName == firstName && account.LastName == lastName && account.Pesel == pesel)
                {
                    customerAccounts.Add(account);
                }
            }
            return customerAccounts;
        }
        */

        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long peselNumber)
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.PeselNumber == peselNumber);
            //'Where' sprawdza każdy element listy i porównuje według warunków podanych przez użytkownika w metodzie
        }

        //Metoda wyszukania odpowiedniego konta
        public Account GetAccount(string accountNo)
        {
            return _accounts.Single(x => x.AccountNumber == accountNo);
            //'Single' zwraca nam dokładnie jeden element listy, który ma dokładnie tą samą wartość jak podana w metodzie

            //UWAGA!!! 
            //Wartość zwracana w 'Single" jest tylko jedna, w przypadku niedokładnych danych, lub ich powtórzenia zwróci błąd!
        }

        //Metoda wypisania użytkowników
        public IEnumerable<string> ListOfCustomers()
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.PeselNumber)).Distinct();
            //'Select' wybiera po kolei dane z każdego konta z systemu i pobiera jego imię, nazwisko i pesel
            //'Distinct' sprawdza, czy dana osoba już pojawiła się na liście, w celu eliminacji powtórek
        }

        //Funkcja zamknięcia miesiąca
        public void CloseMonth()
        {
            foreach (SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                account.AddInterest(0.04M);
            }

            foreach(BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(5.00M);
            }
            //'is' pomaga nam w sprawdzeniu, czy dana klasa jest pochodną klasy którą przeszukujemy
        }

        //Wpłata...
        public void AddMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }

        //i wypłata
        public void TakeMoney(string accountNo, decimal value)
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }
    }
}
