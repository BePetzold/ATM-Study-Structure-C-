using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace ATM_Case_Study
{
    class Autentication
    {
        public int _currentAccountNumber { get; set; }
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
        public void RegisterUser()
        {
            Screen _screen = new Screen();
            Keypad _keypad = new Keypad();
            Sleep(500);
            Clear();
            Screen.DisplayMessageLine("Please enter your account number: ");
            int accountNumber = Keypad.GetInput();
            Screen.DisplayMessageLine("Enter your PIN: ");
            int pinCode = Keypad.GetInput();
            AuthenticateUser(accountNumber, pinCode);
            if (!GetIsAutenticated())
            {
                _currentAccountNumber = accountNumber; // Provide access to account if authentication is correct.
            }
            else
            {
                Screen.DisplayMessageLine("Invalid account number or PIN. Please try again."); // Try again if the authentication is incorrect.
            }

            Sleep(500);
        }

    }
}
