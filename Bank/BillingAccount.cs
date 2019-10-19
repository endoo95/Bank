using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BillingAccount : Account
    {
    public BillingAccount(int id, string firstName, string lastName, long peselNumber)
            : base(id, firstName, lastName, peselNumber)
        {
        }

        public override string TypeName()
        {
            return "Konto rozliczeniowe";
        }
    }
}