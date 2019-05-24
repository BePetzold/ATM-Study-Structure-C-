using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Case_Study
{
    class Autentication
    {
        private bool isAutenticated = true;
        private BankDatabase account = new BankDatabase();

        public bool GetIsAutenticated()
        {
            return isAutenticated;
        }

        public void setIsAutenticated()
        {
            isAutenticated = !isAutenticated;
        }
        public void AuthenticateUser(int userAccountNumber, int userPin)
        {
            // attempt to retrieve the account with the account number
            Account currentAccountNumber;
            currentAccountNumber = account.GetAccount(userAccountNumber);
            if (currentAccountNumber != null)
            {
                if(currentAccountNumber.ValidatePin(userPin))
                {
                    setIsAutenticated();
                }
            }
        }
    }
}
