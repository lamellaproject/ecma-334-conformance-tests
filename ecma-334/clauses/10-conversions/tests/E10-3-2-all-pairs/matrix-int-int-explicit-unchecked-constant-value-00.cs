/*
Rules: E10-3-2-all-pairs; E12-23-numeric
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
            const int input = -2147483648;
            int result = unchecked((int)input);
            Check(result==-2147483648, "int-int-explicit-unchecked-constant-0");
        }
        {
            const int input = 2147483647;
            int result = unchecked((int)input);
            Check(result==2147483647, "int-int-explicit-unchecked-constant-1");
        }
        {
            const int input = 0;
            int result = unchecked((int)input);
            Check(result==0, "int-int-explicit-unchecked-constant-2");
        }
        {
            const int input = 1;
            int result = unchecked((int)input);
            Check(result==1, "int-int-explicit-unchecked-constant-3");
        }
        {
            const int input = -1;
            int result = unchecked((int)input);
            Check(result==-1, "int-int-explicit-unchecked-constant-4");
        }
        {
            const int input = -2147483647;
            int result = unchecked((int)input);
            Check(result==-2147483647, "int-int-explicit-unchecked-constant-5");
        }
        {
            const int input = 2147483646;
            int result = unchecked((int)input);
            Check(result==2147483646, "int-int-explicit-unchecked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
