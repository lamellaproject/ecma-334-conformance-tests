/*
Rules: E10-3-2-all-pairs; E10-3-2-int; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const int input = -2147483648;
            uint result = unchecked((uint)input);
            Check(result==2147483648U, "int-uint-explicit-unchecked-constant-0");
        }
        {
            const int input = 2147483647;
            uint result = unchecked((uint)input);
            Check(result==2147483647U, "int-uint-explicit-unchecked-constant-1");
        }
        {
            const int input = 0;
            uint result = unchecked((uint)input);
            Check(result==0U, "int-uint-explicit-unchecked-constant-2");
        }
        {
            const int input = 1;
            uint result = unchecked((uint)input);
            Check(result==1U, "int-uint-explicit-unchecked-constant-3");
        }
        {
            const int input = -1;
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "int-uint-explicit-unchecked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
