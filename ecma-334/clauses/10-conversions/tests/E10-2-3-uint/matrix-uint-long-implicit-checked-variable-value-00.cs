/*
Rules: E10-2-3-uint
Authority: ECMA-334 7th ed 10.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/10-conversions/generators/standard-matrices.py
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        { uint input = 0U; long result = checked(input); Check(result==0L, "uint-long-implicit-checked-variable-0"); }
        {
            uint input = 4294967295U;
            long result = checked(input);
            Check(result==4294967295L, "uint-long-implicit-checked-variable-1");
        }
        { uint input = 1U; long result = checked(input); Check(result==1L, "uint-long-implicit-checked-variable-2"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
