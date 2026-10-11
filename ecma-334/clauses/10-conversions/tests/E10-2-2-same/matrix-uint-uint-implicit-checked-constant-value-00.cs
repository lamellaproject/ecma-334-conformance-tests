/*
Rules: E10-2-2-same; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.2
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
        {
            const uint input = 0U;
            uint result = checked(input);
            Check(result==0U, "uint-uint-implicit-checked-constant-0");
        }
        {
            const uint input = 4294967295U;
            uint result = checked(input);
            Check(result==4294967295U, "uint-uint-implicit-checked-constant-1");
        }
        {
            const uint input = 1U;
            uint result = checked(input);
            Check(result==1U, "uint-uint-implicit-checked-constant-2");
        }
        {
            const uint input = 4294967294U;
            uint result = checked(input);
            Check(result==4294967294U, "uint-uint-implicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
