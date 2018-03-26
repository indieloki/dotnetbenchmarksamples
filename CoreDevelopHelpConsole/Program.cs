using dotnetbenchmarksamples.DatabaseTests;
using System;

namespace CoreDevelopHelpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Select1 select = new Select1();
            select.PostgreEfFromProcedure();
        }
    }
}
