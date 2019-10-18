using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class SavingsAccount : Account //Dziedziczenie klasy
    {
    public SavingsAccount(int id, string firstName, string lastName, long peselnumber) 
            : base(id, firstName, lastName, peselnumber) //Referencja do klasy nadrzędnej
        { 
        }

        public override string TypeName()
        {
            return "Konto oszczędnościowe";
        }
    }
}
