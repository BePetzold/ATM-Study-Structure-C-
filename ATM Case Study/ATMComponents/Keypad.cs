using System;
using static System.Console;

namespace ATM_Case_Study
{
    public class Keypad
    {
        public static int GetInput()
        {
            int.TryParse(ReadLine(), out int output);
            return output;
        }
    }
}
