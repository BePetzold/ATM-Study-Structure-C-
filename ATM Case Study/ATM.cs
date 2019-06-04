using static System.Console;
using static System.Threading.Thread;

namespace ATM_Case_Study
{
     public class ATM
    {
        /// <summary>
        /// account information database
        /// </summary>
        private BankDatabase _bankDatabase;
        /// <summary>
        /// whether user is authenticated
        /// </summary>
        private Autentication autentication = new Autentication();

        /// <summary>
        /// no-argument ATM constructor initializes instance variables
        /// </summary>
        public ATM()
        {
            _bankDatabase = new BankDatabase();
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

        private void PerformTransactions()
        {
            // local variable to store transaction currently being processed
            Transaction currentTransaction = null;
            bool isUserExited = false; // user has not chosen to exit
            // loop while user has not chosen option to exit system
            while (!isUserExited)
            {
                Clear();
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
                        Clear();
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

        public void Run()
        {
            // welcome and authenticate user; perform transactions
            while (true)
            {
                while (autentication.GetIsAutenticated()) // loop while user is not yet authenticated
                {
                    Screen.DisplayMessageLine("Welcome!");
                    autentication.RegisterUser();
                }
                PerformTransactions(); // user is now authenticated
                autentication.setIsAutenticated();
                autentication._currentAccountNumber = 0;
                Screen.DisplayMessageLine("Thank you! Goodbye!");
                Sleep(2000);
            }
        }
    }
}
