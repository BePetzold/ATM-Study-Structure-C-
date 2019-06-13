using System;
using static System.Threading.Thread;

namespace ATM_Case_Study
{
    class TransactionAdapter
    {
        /// <summary>
        /// account information database
        /// </summary>
        private BankDatabase _bankDatabase = new BankDatabase();
        /// <summary>
        /// whether user is authenticated
        /// </summary>
        private Autentication autentication = new Autentication();

        public TransactionAdapter(Autentication aut)
        {
            autentication = aut;
        }

        private Transaction CreateTransaction(MenuOption type)
        {
            Transaction temp = null;
            switch (type)
            {
                case MenuOption.BalanceInquiry:
                    temp = new BalanceInquiry(autentication._currentAccountNumber, _bankDatabase);
                    break;
                case MenuOption.Withdrawal:
                    temp = new Withdrawal(autentication._currentAccountNumber, _bankDatabase);
                    break;
                case MenuOption.Deposit:
                    temp = new Deposit(autentication._currentAccountNumber, _bankDatabase);
                    break;
            }

            return temp;
        }

        public void PerformTransactions()
        {
            // local variable to store transaction currently being processed
            Transaction currentTransaction = null;
            bool isUserExited = false; // user has not chosen to exit
            // loop while user has not chosen option to exit system
            while (!isUserExited)
            {
                Console.Clear();
                MenuOption menuSelect = DisplayMainMenu();
                switch (menuSelect)
                {
                    case MenuOption.BalanceInquiry:
                    case MenuOption.Withdrawal:
                    case MenuOption.Deposit:
                        currentTransaction = CreateTransaction(menuSelect);
                        currentTransaction.Execute();
                        break;
                    case MenuOption.Exit:
                        Screen.DisplayMessageLine("Exiting the system...");
                        isUserExited = true;
                        Sleep(3000);
                        Console.Clear();
                        break;
                    // Try again if you enter a value other than the enum values, regardless of the GetInput method.
                    default:
                        Screen.DisplayMessageLine("You did not enter a valid selection. Try again.");
                        break;
                }
            }
        }

        private MenuOption DisplayMainMenu()
        {
            Screen.DisplayMessage("MAIN MENU: " +
                                  "\n\n 1 - View my balance" +
                                    "\n 2 - Withdraw cash" +
                                    "\n 3 - Deposit funds" +
                                    "\n 4 - Exit" +
                                    "\n Please enter a choise: ");

            MenuOption menuSelect = (MenuOption)Keypad.GetInput();
            return menuSelect;
        }
    }
}
