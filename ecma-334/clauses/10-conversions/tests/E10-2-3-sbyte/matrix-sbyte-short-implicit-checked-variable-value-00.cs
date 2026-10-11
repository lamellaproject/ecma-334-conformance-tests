/*
Rules: E10-2-3-sbyte
Authority: ECMA-334 7th ed 10.2.3
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
            short result = checked(input);
            Check(result==(short)(-128), "sbyte-short-implicit-checked-variable-0");
        }
        {
            sbyte input = (sbyte)(127);
            short result = checked(input);
            Check(result==(short)(127), "sbyte-short-implicit-checked-variable-1");
        }
        {
            sbyte input = (sbyte)(0);
            short result = checked(input);
            Check(result==(short)(0), "sbyte-short-implicit-checked-variable-2");
        }
        {
            sbyte input = (sbyte)(1);
            short result = checked(input);
            Check(result==(short)(1), "sbyte-short-implicit-checked-variable-3");
        }
        {
            sbyte input = (sbyte)(-1);
            short result = checked(input);
            Check(result==(short)(-1), "sbyte-short-implicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
