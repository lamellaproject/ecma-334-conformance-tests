/*
Rules: E10-3-2-all-pairs; E10-3-2-sbyte; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const sbyte input = (sbyte)(127);
            char result = checked((char)input);
            Check(result==(char)(127), "sbyte-char-explicit-checked-constant-1");
        }
        {
            const sbyte input = (sbyte)(0);
            char result = checked((char)input);
            Check(result==(char)(0), "sbyte-char-explicit-checked-constant-2");
        }
        {
            const sbyte input = (sbyte)(1);
            char result = checked((char)input);
            Check(result==(char)(1), "sbyte-char-explicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
