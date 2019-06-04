using static System.Threading.Thread;

namespace ATM_Case_Study
{
    public class BalanceInquiry : Transaction
    {
        public BalanceInquiry(int userAccountNumber, BankDatabase atmBankDatabase) 
                              : base(userAccountNumber, atmBankDatabase) { }

        public override void Execute()
        {
            BankDatabase bankDatabase = base.BankDatabase;

            decimal availableBalance = bankDatabase.getAvailableBalance(AccountNumber);
            decimal totalBalance = bankDatabase.getTotalBalance(AccountNumber);

            Screen.DisplayMessageLine("\nBalance Information:");
            Screen.DisplayMessage(" - Available balance: ");
            Screen.DisplayDollarAmount(availableBalance);
            Screen.DisplayMessage("\n - Total balance:     ");
            Screen.DisplayDollarAmount(totalBalance);
            Screen.DisplayMessageLine(string.Empty);

            Sleep(5000);
        }
    }
}