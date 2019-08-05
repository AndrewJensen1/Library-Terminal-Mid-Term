using System;
using System.Collections.Generic;
using System.Text;

namespace Libarary_Terminal_Mid_Term_Project
{
    class Validator
    {
        
        public static bool IsValidInt(string input)
        {
            bool isValid = int.TryParse(input, out int result);

            if(isValid == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
