using static System.Console;

namespace ATM_Case_Study
{
    public class Screen
    {
        public static void DisplayMessage(string message)
        {
            Write(message);
        }

        public static void DisplayMessageLine(string message)
        {
            WriteLine(message);
        }

        public static void DisplayDollarAmount(decimal amount)
        {
            Write(amount.ToString("$#.00"));
        }
    }
}
