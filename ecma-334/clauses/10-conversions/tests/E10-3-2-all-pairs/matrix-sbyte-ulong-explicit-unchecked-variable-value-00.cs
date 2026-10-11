/*
Rules: E10-3-2-all-pairs; E10-3-2-sbyte
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
            sbyte input = (sbyte)(-128);
            ulong result = unchecked((ulong)input);
            Check(result==18446744073709551488UL, "sbyte-ulong-explicit-unchecked-variable-0");
        }
        {
            sbyte input = (sbyte)(127);
            ulong result = unchecked((ulong)input);
            Check(result==127UL, "sbyte-ulong-explicit-unchecked-variable-1");
        }
        {
            sbyte input = (sbyte)(0);
            ulong result = unchecked((ulong)input);
            Check(result==0UL, "sbyte-ulong-explicit-unchecked-variable-2");
        }
        {
            sbyte input = (sbyte)(1);
            ulong result = unchecked((ulong)input);
            Check(result==1UL, "sbyte-ulong-explicit-unchecked-variable-3");
        }
        {
            sbyte input = (sbyte)(-1);
            ulong result = unchecked((ulong)input);
            Check(result==18446744073709551615UL, "sbyte-ulong-explicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
