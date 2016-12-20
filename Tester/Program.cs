using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SabreAPI;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> f = REST.GetChampions(true);
            List<string> g = REST.GetCharacters(true);
        }
    }
}
