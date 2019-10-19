using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class SavingsAccount : Account //Dziedziczenie klasy
    {
    public SavingsAccount(int id, string firstName, string lastName, long peselNumber) 
            : base(id, firstName, lastName, peselNumber) //Referencja do klasy nadrzędnej
        { 
        }

        public override string TypeName()
        {
            return "Konto oszczędnościowe";
        }
    }
}
