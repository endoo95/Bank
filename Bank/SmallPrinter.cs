﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class SmallPrinter : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine(account.TypeName());
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Imię właściciela: {0}", account.FirstName);
            Console.WriteLine("Nazwisko właściciela: {0}", account.LastName);
            Console.WriteLine();
        }
    }
}
