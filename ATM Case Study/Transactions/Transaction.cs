namespace ATM_Case_Study
{
    public abstract class Transaction
    {
        public int AccountNumber { get; private set; }
        public BankDatabase BankDatabase { get; private set; }
        
        public Transaction(int userAccountNumber, BankDatabase atmBankDatabase)
        {
            this.AccountNumber = userAccountNumber;
            this.BankDatabase = atmBankDatabase;
        }

        public abstract void Execute();


    }
}
