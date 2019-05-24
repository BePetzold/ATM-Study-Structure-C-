using static System.Console;
using static System.Threading.Thread;


namespace ATM_Case_Study
{
    /// <summary>
    /// constants corresponding to main menu options
    /// </summary>
    internal enum MenuOption
    {
        BalanceInquiry = 1,
        Withdrawal = 2,
        Deposit = 3,
        Exit = 4
    };

    public class ATM
    {
        /// <summary>
        /// account information database
        /// </summary>
        private BankDatabase _bankDatabase;
        /// <summary>
        /// ATM's cash dispenser
        /// </summary>
        private CashDispenser _cashDispenser;
        /// <summary>
        /// current user's account number
        /// </summary>
        private int _currentAccountNumber;
        /// <summary>
        /// ATM's deposit slot
        /// </summary>
        private DepositSlot _depositSlot;
        /// <summary>
        /// ATM's keypad
        /// </summary>
        private Keypad _keypad;
        /// <summary>
        /// ATM's screen
        /// </summary>
        private Screen _screen;
        /// <summary>
        /// whether user is authenticated
        /// </summary>
        private Autentication autentication = new Autentication();

        /// <summary>
        /// no-argument ATM constructor initializes instance variables
        /// </summary>
        public ATM()
        {
            _currentAccountNumber = 0;
            _depositSlot = new DepositSlot();
            _keypad = new Keypad();
            _screen = new Screen();
            _cashDispenser = new CashDispenser();
            _bankDatabase = new BankDatabase();
        }

        private void AuthenticateUser()
        {
            Sleep(500);
            Clear();
            _screen.DisplayMessageLine("Please enter your account number: ");
            int accountNumber = _keypad.GetInput();
            _screen.DisplayMessageLine("Enter your PIN: ");
            int pinCode = _keypad.GetInput();

            autentication.AuthenticateUser(accountNumber, pinCode);
            if (!autentication.GetIsAutenticated())
            {
                _currentAccountNumber = accountNumber; // Provide access to account if authentication is correct.
            }
            else
                _screen.DisplayMessageLine("Invalid account number or PIN. Please try again. "); // Try again if the authentication is incorrect.

            Sleep(3000);
        }

        private Transaction CreateTransaction(MenuOption type)
        {
            Transaction temp = null;

            switch (type)
            {
                case MenuOption.BalanceInquiry:
                    temp = new BalanceInquiry(_currentAccountNumber, _screen, _bankDatabase);
                    break;
                case MenuOption.Withdrawal:
                    temp = new Withdrawal(_currentAccountNumber, _screen, _bankDatabase, _keypad, _cashDispenser);
                    break;
                case MenuOption.Deposit:
                    temp = new Deposit(_currentAccountNumber, _screen, _bankDatabase, _keypad, _depositSlot);
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
                        _screen.DisplayMessageLine("Exiting the system...");
                        isUserExited = true;
                        Sleep(3000);
                        Clear();
                        break;
                    // Try again if you enter a value other than the enum values, regardless of the GetInput method.
                    default: _screen.DisplayMessageLine("You did not enter a valid selection. Try again.");
                        break;
                }
            }
        }

        private MenuOption DisplayMainMenu()
        {
            _screen.DisplayMessage("MAIN MENU: " +
                                  "\n\n 1 - View my balance" +
                                    "\n 2 - Withdraw cash" +
                                    "\n 3 - Deposit funds" +
                                    "\n 4 - Exit" +
                                    "\n Please enter a choise: ");

            MenuOption menuSelect = (MenuOption)_keypad.GetInput();
            return menuSelect;
        }

        public void Run()
        {
            // welcome and authenticate user; perform transactions
            while (true)
            {
                while (autentication.GetIsAutenticated()) // loop while user is not yet authenticated
                {
                    _screen.DisplayMessageLine("Welcome!");
                    AuthenticateUser();
                }

                PerformTransactions(); // user is now authenticated
                autentication.setIsAutenticated();
                _currentAccountNumber = 0;
                _screen.DisplayMessageLine("Thank you! Goodbye!");
                Sleep(2000);
            }
        }
    }
}
