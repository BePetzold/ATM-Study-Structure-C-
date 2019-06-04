namespace ATM_Case_Study
{
    public class CashDispenser
    {
        private const int INITIAL_COUNT = 500; // the default initial number of bills in the cash dispenser
        private static int _billCount = INITIAL_COUNT; // number of $20 bills remaining

        public static void DispenseCash(decimal amount) => _billCount -= (int)(amount / 20);

        public static bool IsSufficiantCashAvailable(decimal amount) => _billCount >= (int)(amount / 20);
    }
}
