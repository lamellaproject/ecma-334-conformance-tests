/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
        {
            ulong? input = 0UL;
            decimal result = checked((decimal)input);
            Check(result==0m, "nullable-ulong-decimal-explicit-checked-unwrap-0");
        }
        {
            ulong? input = 18446744073709551615UL;
            decimal result = checked((decimal)input);
            Check(result==18446744073709551615m, "nullable-ulong-decimal-explicit-checked-unwrap-1");
        }
        {
            ulong? input = 1UL;
            decimal result = checked((decimal)input);
            Check(result==1m, "nullable-ulong-decimal-explicit-checked-unwrap-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
