/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const decimal input = 0m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-constant-2");
        }
        {
            const decimal input = 1m;
            int result = unchecked((int)input);
            Check(result==1, "decimal-int-explicit-unchecked-constant-3");
        }
        {
            const decimal input = 0.1m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-constant-5");
        }
        {
            const decimal input = 1E-28m;
            int result = unchecked((int)input);
            Check(result==0, "decimal-int-explicit-unchecked-constant-7");
        }
        {
            const decimal input = 2147483646m;
            int result = unchecked((int)input);
            Check(result==2147483646, "decimal-int-explicit-unchecked-constant-12");
        }
        {
            const decimal input = 2147483647m;
            int result = unchecked((int)input);
            Check(result==2147483647, "decimal-int-explicit-unchecked-constant-13");
        }
        {
            const decimal input = 2147483647.75m;
            int result = unchecked((int)input);
            Check(result==2147483647, "decimal-int-explicit-unchecked-constant-16");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
