/*
Rules: E10-2-2-same
Authority: ECMA-334 7th ed 10.2.2
Version: 7.3
Expected: run
Stdout: OK 7
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
            int result = unchecked(input);
            Check(result==-2147483648, "int-int-implicit-unchecked-variable-0");
        }
        {
            int input = 2147483647;
            int result = unchecked(input);
            Check(result==2147483647, "int-int-implicit-unchecked-variable-1");
        }
        { int input = 0; int result = unchecked(input); Check(result==0, "int-int-implicit-unchecked-variable-2"); }
        { int input = 1; int result = unchecked(input); Check(result==1, "int-int-implicit-unchecked-variable-3"); }
        { int input = -1; int result = unchecked(input); Check(result==-1, "int-int-implicit-unchecked-variable-4"); }
        {
            int input = -2147483647;
            int result = unchecked(input);
            Check(result==-2147483647, "int-int-implicit-unchecked-variable-5");
        }
        {
            int input = 2147483646;
            int result = unchecked(input);
            Check(result==2147483646, "int-int-implicit-unchecked-variable-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
