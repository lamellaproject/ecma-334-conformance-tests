/*
Rules: E10-2-3-sbyte; E12-23-numeric
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
            const sbyte input = (sbyte)(-128);
            decimal result = unchecked(input);
            Check(result==-128m, "sbyte-decimal-implicit-unchecked-constant-0");
        }
        {
            const sbyte input = (sbyte)(127);
            decimal result = unchecked(input);
            Check(result==127m, "sbyte-decimal-implicit-unchecked-constant-1");
        }
        {
            const sbyte input = (sbyte)(0);
            decimal result = unchecked(input);
            Check(result==0m, "sbyte-decimal-implicit-unchecked-constant-2");
        }
        {
            const sbyte input = (sbyte)(1);
            decimal result = unchecked(input);
            Check(result==1m, "sbyte-decimal-implicit-unchecked-constant-3");
        }
        {
            const sbyte input = (sbyte)(-1);
            decimal result = unchecked(input);
            Check(result==-1m, "sbyte-decimal-implicit-unchecked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
