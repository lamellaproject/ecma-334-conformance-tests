/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 13
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
            decimal input = 0m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-variable-2");
        }
        {
            decimal input = 1m;
            int result = unchecked((int)input);
            Check(result==1, "decimal-int-explicit-unchecked-variable-3");
        }
        {
            decimal input = -1m;
            int result = unchecked((int)input);
            Check(result==-1, "decimal-int-explicit-unchecked-variable-4");
        }
        {
            decimal input = 0.1m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-variable-5");
        }
        {
            decimal input = -0.1m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-variable-6");
        }
        {
            decimal input = 1E-28m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-variable-7");
        }
        {
            decimal input = -1E-28m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-variable-8");
        }
        {
            decimal input = -2147483648m;
            int result = unchecked((int)input);
            Check(result==-2147483648, "decimal-int-explicit-unchecked-variable-10");
        }
        {
            decimal input = -2147483647m;
            int result = unchecked((int)input);
            Check(result==-2147483647, "decimal-int-explicit-unchecked-variable-11");
        }
        {
            decimal input = 2147483646m;
            int result = unchecked((int)input);
            Check(result==2147483646, "decimal-int-explicit-unchecked-variable-12");
        }
        {
            decimal input = 2147483647m;
            int result = unchecked((int)input);
            Check(result==2147483647, "decimal-int-explicit-unchecked-variable-13");
        }
        {
            decimal input = -2147483648.75m;
            int result = unchecked((int)input);
            Check(result==-2147483648, "decimal-int-explicit-unchecked-variable-15");
        }
        {
            decimal input = 2147483647.75m;
            int result = unchecked((int)input);
            Check(result==2147483647, "decimal-int-explicit-unchecked-variable-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
