/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 12
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
            const double input = 0.0d;
            int result = unchecked((int)input);
            Check(result==0, "double-int-explicit-unchecked-constant-2");
        }
        {
            const double input = -0.0d;
            int result = unchecked((int)input);
            Check(result==0, "double-int-explicit-unchecked-constant-3");
        }
        {
            const double input = 1.0d;
            int result = unchecked((int)input);
            Check(result==1, "double-int-explicit-unchecked-constant-4");
        }
        {
            const double input = -1.0d;
            int result = unchecked((int)input);
            Check(result==-1, "double-int-explicit-unchecked-constant-5");
        }
        {
            const double input = 0.75d;
            int result = unchecked((int)input);
            Check(result==0, "double-int-explicit-unchecked-constant-6");
        }
        {
            const double input = -0.75d;
            int result = unchecked((int)input);
            Check(result==0, "double-int-explicit-unchecked-constant-7");
        }
        {
            const double input = -2147483648.0d;
            int result = unchecked((int)input);
            Check(result==-2147483648, "double-int-explicit-unchecked-constant-12");
        }
        {
            const double input = -2147483647.0d;
            int result = unchecked((int)input);
            Check(result==-2147483647, "double-int-explicit-unchecked-constant-13");
        }
        {
            const double input = 2147483646.0d;
            int result = unchecked((int)input);
            Check(result==2147483646, "double-int-explicit-unchecked-constant-14");
        }
        {
            const double input = 2147483647.0d;
            int result = unchecked((int)input);
            Check(result==2147483647, "double-int-explicit-unchecked-constant-15");
        }
        {
            const double input = -2147483648.75d;
            int result = unchecked((int)input);
            Check(result==-2147483648, "double-int-explicit-unchecked-constant-17");
        }
        {
            const double input = 2147483647.75d;
            int result = unchecked((int)input);
            Check(result==2147483647, "double-int-explicit-unchecked-constant-18");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
