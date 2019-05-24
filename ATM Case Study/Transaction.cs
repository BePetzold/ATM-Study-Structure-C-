namespace ATM_Case_Study
{
    public abstract class Transaction
    {
        public int AccountNumber { get; private set; }
        public BankDatabase BankDatabase { get; private set; }
        public Screen Screen { get; private set; }
        
        public Transaction(int userAccountNumber, BankDatabase atmBankDatabase, Screen atmScreen)
        {
            this.AccountNumber = userAccountNumber;
            this.BankDatabase = atmBankDatabase;
            this.Screen = atmScreen;
        }

        public abstract void Execute();
    }
}
