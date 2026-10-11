/*
Rules: E10-2-3-int
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 5
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        {
            int input = -2147483648;
            long result = unchecked(input);
            Check(result==-2147483648L, "int-long-implicit-unchecked-variable-0");
        }
        {
            int input = 2147483647;
            long result = unchecked(input);
            Check(result==2147483647L, "int-long-implicit-unchecked-variable-1");
        }
        { int input = 0; long result = unchecked(input); Check(result==0L, "int-long-implicit-unchecked-variable-2"); }
        { int input = 1; long result = unchecked(input); Check(result==1L, "int-long-implicit-unchecked-variable-3"); }
        {
            int input = -1;
            long result = unchecked(input);
            Check(result==-1L, "int-long-implicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
