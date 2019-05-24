using static System.Threading.Thread;

namespace ATM_Case_Study
{
    public class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int userAccountNumber, Screen atmScreen, BankDatabase atmBankDatabase) 
            : base(userAccountNumber, atmBankDatabase, atmScreen) { }

        public override void Execute()
        {
            BankDatabase bankDatabase = base.BankDatabase;
            Screen screen = base.Screen;

            decimal availableBalance = bankDatabase.getAvailableBalance(AccountNumber);
            decimal totalBalance = bankDatabase.getTotalBalance(AccountNumber);

            screen.DisplayMessageLine("\nBalance Information:");
            screen.DisplayMessage(" - Available balance: ");
            screen.DisplayDollarAmount(availableBalance);
            screen.DisplayMessage("\n - Total balance:     ");
            screen.DisplayDollarAmount(totalBalance);
            screen.DisplayMessageLine(string.Empty);

            Sleep(5000);
        }
    }
}