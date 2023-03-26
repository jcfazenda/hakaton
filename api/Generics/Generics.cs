using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace api.Generics
{
 
    public class Generics
    {
        public static bool IsEmail(string email)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(email))
                return true;

            return false;
        }
    }
     

    public class Resposta
    {
        public List<Choice> choices { get; set; }
        public Data[] data { get; set; }

        public class Choice
        {
            public string text { get; set; }
        }

        public class Data
        {
            public string url { get; set; }

        }
    }


}
