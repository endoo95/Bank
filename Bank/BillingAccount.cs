using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BillingAccount : Account //Dziedziczenie klasy
    {
    public BillingAccount(int id, string firstName, string lastName, long peselNumber)
            : base(id, firstName, lastName, peselNumber) //Referencja do klasy nadrzędnej
        {
        }

        public void TakeCharge(decimal charge)
        {
            Balance -= Balance - charge;
        }

        public override string TypeName()
        {
            return "Konto rozliczeniowe";
        }
    }
}