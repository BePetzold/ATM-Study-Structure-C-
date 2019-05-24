using System;
using static System.Console;

namespace ATM_Case_Study
{
    public class Keypad
    {
        public int GetInput()
        {
            int.TryParse(ReadLine(), out int output);
            return output;
        }
    }
}
