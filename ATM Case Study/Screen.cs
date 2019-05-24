using static System.Console;

namespace ATM_Case_Study
{
    public class Screen
    {
        public void DisplayMessage(string message)
        {
            Write(message);
        }

        public void DisplayMessageLine(string message)
        {
            WriteLine(message);
        }

        public void DisplayDollarAmount(decimal amount)
        {
            Write(amount.ToString("$#.00"));
        }
    }
}
