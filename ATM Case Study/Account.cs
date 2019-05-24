namespace ATM_Case_Study
{
    public class Account
    {
        public int AccountNumber { get; private set; }
        public decimal AvailableBalance { get; private set; }
        private int Pin { get; set; }
        public decimal TotalBalance { get; private set; }

        public Account(int accountNumber, int pin, decimal totalBalance, decimal availableBalance)
        {
            AccountNumber = accountNumber;
            Pin = pin;
            TotalBalance = totalBalance;
            AvailableBalance = availableBalance;
        }

        public void Credit(decimal amount)
        {
            TotalBalance += amount;
        }

        public void Debit(decimal amount)
        {
            AvailableBalance -= amount;
            TotalBalance -= amount;
        }

        public bool ValidatePin(int userPin)
        {
            if(userPin == Pin)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}