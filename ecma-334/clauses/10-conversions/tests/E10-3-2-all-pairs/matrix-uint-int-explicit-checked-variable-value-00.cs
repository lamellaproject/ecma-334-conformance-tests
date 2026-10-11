/*
Rules: E10-3-2-all-pairs; E10-3-2-uint
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 4
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        { uint input = 0U; int result = checked((int)input); Check(result==0, "uint-int-explicit-checked-variable-0"); }
        { uint input = 1U; int result = checked((int)input); Check(result==1, "uint-int-explicit-checked-variable-2"); }
        {
            uint input = 2147483646U;
            int result = checked((int)input);
            Check(result==2147483646, "uint-int-explicit-checked-variable-3");
        }
        {
            uint input = 2147483647U;
            int result = checked((int)input);
            Check(result==2147483647, "uint-int-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
