/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 10
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
            decimal input = 0m;
            ulong result = checked((ulong)input);
            Check(result==0UL, "decimal-ulong-explicit-checked-variable-2");
        }
        {
            decimal input = 1m;
            ulong result = checked((ulong)input);
            Check(result==1UL, "decimal-ulong-explicit-checked-variable-3");
        }
        {
            decimal input = 0.1m;
            ulong result = checked((ulong)input);
            Check(result==0UL, "decimal-ulong-explicit-checked-variable-5");
        }
        {
            decimal input = -0.1m;
            ulong result = checked((ulong)input);
            Check(result==0UL, "decimal-ulong-explicit-checked-variable-6");
        }
        {
            decimal input = 1E-28m;
            ulong result = checked((ulong)input);
            Check(result==0UL, "decimal-ulong-explicit-checked-variable-7");
        }
        {
            decimal input = -1E-28m;
            ulong result = checked((ulong)input);
            Check(result==0UL, "decimal-ulong-explicit-checked-variable-8");
        }
        {
            decimal input = 18446744073709551614m;
            ulong result = checked((ulong)input);
            Check(result==18446744073709551614UL, "decimal-ulong-explicit-checked-variable-9");
        }
        {
            decimal input = 18446744073709551615m;
            ulong result = checked((ulong)input);
            Check(result==18446744073709551615UL, "decimal-ulong-explicit-checked-variable-10");
        }
        {
            decimal input = -0.75m;
            ulong result = checked((ulong)input);
            Check(result==0UL, "decimal-ulong-explicit-checked-variable-12");
        }
        {
            decimal input = 18446744073709551615.75m;
            ulong result = checked((ulong)input);
            Check(result==18446744073709551615UL, "decimal-ulong-explicit-checked-variable-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
