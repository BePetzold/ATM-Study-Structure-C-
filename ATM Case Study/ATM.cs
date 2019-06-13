using static System.Threading.Thread;

namespace ATM_Case_Study
{
     public class ATM
    {
        private Autentication autentication = new Autentication();

        public void Run()
        {
            TransactionAdapter transaction = new TransactionAdapter(autentication);
            // welcome and authenticate user; perform transactions
            while (true)
            {
                while (autentication.GetIsAutenticated()) // loop while user is not yet authenticated
                {
                    Screen.DisplayMessageLine("Welcome!");
                    autentication.RegisterUser();
                }
                transaction.PerformTransactions(); // user is now authenticated
                autentication.setIsAutenticated();
                autentication._currentAccountNumber = 0;
                Screen.DisplayMessageLine("Thank you! Goodbye!");
                Sleep(2000);
            }
        }
    }
}
