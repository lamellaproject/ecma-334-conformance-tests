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
            uint result = unchecked((uint)input);
            Check(result==4294967168U, "sbyte-uint-explicit-unchecked-variable-0");
        }
        {
            sbyte input = (sbyte)(127);
            uint result = unchecked((uint)input);
            Check(result==127U, "sbyte-uint-explicit-unchecked-variable-1");
        }
        {
            sbyte input = (sbyte)(0);
            uint result = unchecked((uint)input);
            Check(result==0U, "sbyte-uint-explicit-unchecked-variable-2");
        }
        {
            sbyte input = (sbyte)(1);
            uint result = unchecked((uint)input);
            Check(result==1U, "sbyte-uint-explicit-unchecked-variable-3");
        }
        {
            sbyte input = (sbyte)(-1);
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "sbyte-uint-explicit-unchecked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
