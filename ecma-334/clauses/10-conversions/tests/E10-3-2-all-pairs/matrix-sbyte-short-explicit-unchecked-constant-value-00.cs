/*
Rules: E10-3-2-all-pairs; E10-3-2-sbyte; E12-23-numeric
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
            const sbyte input = (sbyte)(-128);
            short result = unchecked((short)input);
            Check(result==(short)(-128), "sbyte-short-explicit-unchecked-constant-0");
        }
        {
            const sbyte input = (sbyte)(127);
            short result = unchecked((short)input);
            Check(result==(short)(127), "sbyte-short-explicit-unchecked-constant-1");
        }
        {
            const sbyte input = (sbyte)(0);
            short result = unchecked((short)input);
            Check(result==(short)(0), "sbyte-short-explicit-unchecked-constant-2");
        }
        {
            const sbyte input = (sbyte)(1);
            short result = unchecked((short)input);
            Check(result==(short)(1), "sbyte-short-explicit-unchecked-constant-3");
        }
        {
            const sbyte input = (sbyte)(-1);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "sbyte-short-explicit-unchecked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
