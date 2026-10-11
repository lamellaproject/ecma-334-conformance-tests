/*
Rules: E10-2-3-byte; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.3
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
            const byte input = (byte)(0);
            ushort result = unchecked(input);
            Check(result==(ushort)(0), "byte-ushort-implicit-unchecked-constant-0");
        }
        {
            const byte input = (byte)(255);
            ushort result = unchecked(input);
            Check(result==(ushort)(255), "byte-ushort-implicit-unchecked-constant-1");
        }
        {
            const byte input = (byte)(1);
            ushort result = unchecked(input);
            Check(result==(ushort)(1), "byte-ushort-implicit-unchecked-constant-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
