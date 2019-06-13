namespace ATM_Case_Study
{
    public abstract class ITransaction
    {
        public int AccountNumber { get; private set; }
        public BankDatabase BankDatabase { get; private set; }
        
        public ITransaction(int userAccountNumber, BankDatabase atmBankDatabase)
        {
            this.AccountNumber = userAccountNumber;
            this.BankDatabase = atmBankDatabase;
        }

        public abstract void Execute();
    }
}
