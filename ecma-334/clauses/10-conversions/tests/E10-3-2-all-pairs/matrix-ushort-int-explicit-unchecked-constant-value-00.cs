/*
Rules: E10-3-2-all-pairs; E10-3-2-ushort; E12-23-numeric
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
            const ushort input = (ushort)(0);
            int result = unchecked((int)input);
            Check(result==0, "ushort-int-explicit-unchecked-constant-0");
        }
        {
            const ushort input = (ushort)(65535);
            int result = unchecked((int)input);
            Check(result==65535, "ushort-int-explicit-unchecked-constant-1");
        }
        {
            const ushort input = (ushort)(1);
            int result = unchecked((int)input);
            Check(result==1, "ushort-int-explicit-unchecked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
