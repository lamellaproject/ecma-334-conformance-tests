/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            sbyte? input = (sbyte)(-128);
            short result = checked((short)input);
            Check(result==(short)(-128), "nullable-sbyte-short-explicit-checked-unwrap-0");
        }
        {
            sbyte? input = (sbyte)(127);
            short result = checked((short)input);
            Check(result==(short)(127), "nullable-sbyte-short-explicit-checked-unwrap-1");
        }
        {
            sbyte? input = (sbyte)(0);
            short result = checked((short)input);
            Check(result==(short)(0), "nullable-sbyte-short-explicit-checked-unwrap-2");
        }
        {
            sbyte? input = (sbyte)(1);
            short result = checked((short)input);
            Check(result==(short)(1), "nullable-sbyte-short-explicit-checked-unwrap-3");
        }
        {
            sbyte? input = (sbyte)(-1);
            short result = checked((short)input);
            Check(result==(short)(-1), "nullable-sbyte-short-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
