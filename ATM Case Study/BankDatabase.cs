namespace ATM_Case_Study
{
    public class BankDatabase
    {
        private Account[] _accounts;

        public BankDatabase()
        {
            _accounts = new Account[2]; // just 2 accounts for testing
            _accounts[0] = new Account(12345, 54321, 1000, 1200);
            _accounts[1] = new Account(98765, 56789, 200, 200);
        }

        /// <summary>
        /// retrieve Account object containing specified account number
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public Account GetAccount(int accountNumber)
        {
            foreach (Account currentAccount in _accounts)
            {
                // return current account if match found
                if (currentAccount.AccountNumber == accountNumber)
                    return currentAccount;
            }

            return null; // if no matching account was found, return null
        }

        /// <summary>
        /// determine whether user-specified account number and PIN match
        /// those of an account in the database
        /// </summary>
        /// <param name="userAccountNumber"></param>
        /// <param name="userPin"></param>
        /// <returns></returns>

        public void Credit(int userAccountNumber, decimal amount) => GetAccount(userAccountNumber).Credit(amount);
        public void Debit(int userAccountNumber, decimal amount) => GetAccount(userAccountNumber).Debit(amount);
        public decimal getAvailableBalance(int userAccountNumber) => GetAccount(userAccountNumber).AvailableBalance;
        public decimal getTotalBalance(int userAccountNumber) => GetAccount(userAccountNumber).TotalBalance;
    }
}