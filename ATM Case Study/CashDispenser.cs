namespace ATM_Case_Study
{
    public class CashDispenser
    {
        private const int INITIAL_COUNT = 500; // the default initial number of bills in the cash dispenser
        private int _billCount; // number of $20 bills remaining

        public CashDispenser()
        {
            _billCount = INITIAL_COUNT;
        }

        public void DispenseCash(decimal amount) => _billCount -= (int)(amount / 20);
        public bool IsSufficiantCashAvailable(decimal amount) => _billCount >= (int)(amount / 20);
    }
}
