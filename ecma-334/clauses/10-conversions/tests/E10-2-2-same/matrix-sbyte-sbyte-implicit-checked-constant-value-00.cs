/*
Rules: E10-2-2-same; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.2
Version: 7.3
Expected: run
Stdout: OK 7
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
            sbyte result = checked(input);
            Check(result==(sbyte)(-128), "sbyte-sbyte-implicit-checked-constant-0");
        }
        {
            const sbyte input = (sbyte)(127);
            sbyte result = checked(input);
            Check(result==(sbyte)(127), "sbyte-sbyte-implicit-checked-constant-1");
        }
        {
            const sbyte input = (sbyte)(0);
            sbyte result = checked(input);
            Check(result==(sbyte)(0), "sbyte-sbyte-implicit-checked-constant-2");
        }
        {
            const sbyte input = (sbyte)(1);
            sbyte result = checked(input);
            Check(result==(sbyte)(1), "sbyte-sbyte-implicit-checked-constant-3");
        }
        {
            const sbyte input = (sbyte)(-1);
            sbyte result = checked(input);
            Check(result==(sbyte)(-1), "sbyte-sbyte-implicit-checked-constant-4");
        }
        {
            const sbyte input = (sbyte)(-127);
            sbyte result = checked(input);
            Check(result==(sbyte)(-127), "sbyte-sbyte-implicit-checked-constant-5");
        }
        {
            const sbyte input = (sbyte)(126);
            sbyte result = checked(input);
            Check(result==(sbyte)(126), "sbyte-sbyte-implicit-checked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
