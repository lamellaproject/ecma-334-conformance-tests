/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 11
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
            const long input = long.MinValue;
            int result = unchecked((int)input);
            Check(result==0, "long-int-explicit-unchecked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            int result = unchecked((int)input);
            Check(result==-1, "long-int-explicit-unchecked-constant-1");
        }
        {
            const long input = 0L;
            int result = unchecked((int)input);
            Check(result==0, "long-int-explicit-unchecked-constant-2");
        }
        {
            const long input = 1L;
            int result = unchecked((int)input);
            Check(result==1, "long-int-explicit-unchecked-constant-3");
        }
        {
            const long input = -1L;
            int result = unchecked((int)input);
            Check(result==-1, "long-int-explicit-unchecked-constant-4");
        }
        {
            const long input = -2147483649L;
            int result = unchecked((int)input);
            Check(result==2147483647, "long-int-explicit-unchecked-constant-5");
        }
        {
            const long input = -2147483648L;
            int result = unchecked((int)input);
            Check(result==-2147483648, "long-int-explicit-unchecked-constant-6");
        }
        {
            const long input = -2147483647L;
            int result = unchecked((int)input);
            Check(result==-2147483647, "long-int-explicit-unchecked-constant-7");
        }
        {
            const long input = 2147483646L;
            int result = unchecked((int)input);
            Check(result==2147483646, "long-int-explicit-unchecked-constant-8");
        }
        {
            const long input = 2147483647L;
            int result = unchecked((int)input);
            Check(result==2147483647, "long-int-explicit-unchecked-constant-9");
        }
        {
            const long input = 2147483648L;
            int result = unchecked((int)input);
            Check(result==-2147483648, "long-int-explicit-unchecked-constant-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
