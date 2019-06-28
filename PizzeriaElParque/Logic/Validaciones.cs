using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class Validaciones
    {

        public bool NoCodeInyection(String textChaine)
        {
            if (textChaine.Contains("SELECT") || textChaine.Contains("FROM"))
            {
                return false;
            }
            return true;

        }
    }
}
