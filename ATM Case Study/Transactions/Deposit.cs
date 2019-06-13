using static System.Threading.Thread;

namespace ATM_Case_Study
{
    public class Deposit : Transaction
    {
        private decimal _amount;
        private const int CANCELED = 0;

        public Deposit(int userAccountNumber, BankDatabase atmBankDatabase)
                       : base(userAccountNumber, atmBankDatabase)
        {
        }

        public override void Execute()
        {
            _amount = PromptForDepositAmount();

            if (_amount != CANCELED) 
            {
                Screen.DisplayMessage("Please insert a deposit envelope containing ");
                Screen.DisplayDollarAmount(_amount);
                Screen.DisplayMessageLine(" in the deposit slot.");

                bool envelopeReceived = DepositSlot.IsEnvelopeReceived;

                if (envelopeReceived)
                {
                    Screen.DisplayMessageLine(
                        "Your envelope has been received.\n" +
                        "The money just deposited will not be available " +
                        "until we \nverify the amount of any " +
                        "enclosed cash, and any enclosed checks clear.");

                    BankDatabase.Credit(AccountNumber, _amount);
                }
                else
                    Screen.DisplayMessageLine("You did not insert an envelope, so the ATM has canceled your transaction.");
            }
            else
                Screen.DisplayMessageLine("Canceling transaction.");

            Sleep(3000);
        }

        private decimal PromptForDepositAmount()
        {
            Screen.DisplayMessageLine("Please input a deposit amount in CENTS (or 0 to cancel): ");
            int input = Keypad.GetInput();
            return input == CANCELED ? CANCELED : input / 100M;
        }
    }
}

