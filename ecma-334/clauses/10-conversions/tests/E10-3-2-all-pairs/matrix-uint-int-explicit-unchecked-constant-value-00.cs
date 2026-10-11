/*
Rules: E10-3-2-all-pairs; E10-3-2-uint; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            const uint input = 0U;
            int result = unchecked((int)input);
            Check(result==0, "uint-int-explicit-unchecked-constant-0");
        }
        {
            const uint input = 4294967295U;
            int result = unchecked((int)input);
            Check(result==-1, "uint-int-explicit-unchecked-constant-1");
        }
        {
            const uint input = 1U;
            int result = unchecked((int)input);
            Check(result==1, "uint-int-explicit-unchecked-constant-2");
        }
        {
            const uint input = 2147483646U;
            int result = unchecked((int)input);
            Check(result==2147483646, "uint-int-explicit-unchecked-constant-3");
        }
        {
            const uint input = 2147483647U;
            int result = unchecked((int)input);
            Check(result==2147483647, "uint-int-explicit-unchecked-constant-4");
        }
        {
            const uint input = 2147483648U;
            int result = unchecked((int)input);
            Check(result==-2147483648, "uint-int-explicit-unchecked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
