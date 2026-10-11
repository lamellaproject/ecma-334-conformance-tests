/*
Rules: E10-3-2-all-pairs; E10-3-2-ushort
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
            ushort input = (ushort)(0);
            ulong result = checked((ulong)input);
            Check(result==0UL, "ushort-ulong-explicit-checked-variable-0");
        }
        {
            ushort input = (ushort)(65535);
            ulong result = checked((ulong)input);
            Check(result==65535UL, "ushort-ulong-explicit-checked-variable-1");
        }
        {
            ushort input = (ushort)(1);
            ulong result = checked((ulong)input);
            Check(result==1UL, "ushort-ulong-explicit-checked-variable-2");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
