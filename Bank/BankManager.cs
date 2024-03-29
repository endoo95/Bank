﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankManager
    {
        //Deklarowanie zmiennych oraz przypisanie im funkcjonalności w metodzie 'BankManager'
        private AccountsManager _accountsManager;
        private IPrinter _printer;

        public BankManager()
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }

        //Funkcja wypisująca na ekranie opcje do wyboru
        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję: ");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczędnościowe");
            Console.WriteLine("4 - Wpłać pieniądze");
            Console.WriteLine("5 - Wypłać pieniądze");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zakończ miesiąc");
            Console.WriteLine("0 - Zakończ");
        }

        //Funkcja wywołująca prywatną funkcję klasy
        public void Run()
        {
            int action;
            do
            {
                PrintMenu();
                action = SelectAction();

                //Akcja ze względu na numer
                switch (action)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę kont klienta!");
                        Console.ReadKey();
                        ListOfAccounts();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Wybrano dodanie konta rozliczeniowego!");
                        Console.ReadKey();
                        AddBillingAccount();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Wybrano dodanie konta oszczędnościowego!");
                        Console.ReadKey();
                        AddSavingsAccount();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Wybrano wpłatę pieniędzy!");
                        Console.ReadKey();
                        AddMoney();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Wybrano wypłatę pieniędzy!");
                        Console.ReadKey();
                        TakeMoney();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę klientów!");
                        Console.ReadKey();
                        GetAllCustomers();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę wszystkich kont!");
                        Console.ReadKey();
                        GetAllAccounts();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Wybrano zakończenie miesiąca!");
                        Console.ReadKey();
                        Console.Clear();
                        EndOfMonth();
                        break;
                    case 0:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nieprawidłowa akcja!");
                        Console.ReadKey();
                        break;
                }
            }
            while (action != 0);
        }

        //Funkcja wyboru akcji przez użytkownika
        private int SelectAction()
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();
            if (string.IsNullOrEmpty(action))
            {
                return -1;
            }
            return int.Parse(action);
        }
        
        //PRZYPADKI
        //Przypadek 1 - lista kont klienta
        private void ListOfAccounts()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine("Konta klienta {0} {1} | {2}", data.FirstName, data.LastName, data.PeselNumber);

            foreach (Account account in _accountsManager.GetAllAccountsFor(data.FirstName, data.LastName, data.PeselNumber))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }

        //Przypadek 2 - dodanie konta rozliczeniowego
        private void AddBillingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account billingAccount = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.PeselNumber);

            Console.WriteLine("Utworzone nowe konto klienta dla {0} {1}!", data.FirstName, data.LastName);
            Console.WriteLine();
            _printer.Print(billingAccount);
            Console.ReadKey();
        }

        //Przypadek 3 - dodanie konta oszczędnościowego
        //TODO: W przyszłości zmienić na dodanie konta z wyborem.
        private void AddSavingsAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingsAccount = _accountsManager.CreateSavingsAccount(data.FirstName, data.LastName, data.PeselNumber);

            Console.WriteLine("Utworzone nowe konto klienta dla {0} {1}!", data.FirstName, data.LastName);
            Console.WriteLine();
            _printer.Print(savingsAccount);
            Console.ReadKey();
        }

        //Przypadek 4 - Wpłata na konto
        private void AddMoney()
        {
            Console.Clear();

            string accountNo;
            decimal value;

            Console.Write("Podaj numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Podaj kwotę wpłaty: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.AddMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);
            Console.ReadKey();
        }

        //Przypadek 5 - Wypłata pieniędzy
        //To samo co z kontami, uprościć

        private void TakeMoney()
        {
            Console.Clear();

            string accountNo;
            decimal value;

            Console.Write("Podaj numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Podaj kwotę wypłaty: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.TakeMoney(accountNo, value);

            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);
            Console.ReadKey();
        }

        //Przypadek 6 - Wypisanie klientów banku
        private void GetAllCustomers()
        {
            Console.Clear();
            Console.WriteLine("Lista wszystkich klientów banku: ");
            foreach(string customer in _accountsManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }

        //Przypadek 7 - Wypisanie wszystkich kont w banku
        private void GetAllAccounts()
        {
            Console.Clear();
            Console.WriteLine("Lista wszystkich kont w banku: ");
            foreach(Account account in _accountsManager.GetAllAccounts())
            {
                _printer.Print(account);
            }

            Console.ReadKey();
        }

        //Przypadek 8 - Koniec miesiąca
        private void EndOfMonth()
        {
            string answer;

            do
            {
                Console.Write("Czy na pewno zakończyć miesiąc? (Y/N): ");
                answer = Console.ReadLine();

                if (answer == "y" || answer == "Y")
                {
                    Console.Clear();
                    Console.WriteLine("Kończę miesiąc!");
                    _accountsManager.CloseMonth();
                    Console.ReadKey();
                    GetAllAccounts();
                    break;
                } 
                else if (answer == "n" || answer == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Wychodzę do menu!");
                    Console.ReadKey();
                    break;
                } 
                else
                {
                    Console.Clear();
                    Console.WriteLine("Podaj prawidłowe dane!");
                }


            } while (!(answer == "y" || answer == "Y" || answer == "n" || answer == "N"));
        }

        //FUNKCJE DO PRZYPADKÓW
        //Pobranie danych klienta
        private CustomerData ReadCustomerData()
        {
            string firstName;
            string lastName;
            string peselNumber;
            Console.WriteLine("Podaj dane klienta!");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            peselNumber = Console.ReadLine();

            Console.WriteLine();

            return new CustomerData(firstName, lastName, peselNumber);
        }
    }

    //Dodatkowa klasa. Używać jej będziemy tylko i wyłącznie w 'Bank Manager', dlatego pozostaje w pliku tejże klasy
    class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long PeselNumber { get; }

        //KONSTRUKTOR
        //Przypisanie wartości z zamianą 'string' na 'long' w przypadku numeru pesel.
        public CustomerData(string firstName, string lastName, string peselNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PeselNumber = long.Parse(peselNumber);
        }
    }
}