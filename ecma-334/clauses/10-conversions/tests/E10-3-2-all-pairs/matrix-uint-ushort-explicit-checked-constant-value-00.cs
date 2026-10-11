/*
Rules: E10-3-2-all-pairs; E10-3-2-uint; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 4
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
            const uint input = 0U;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "uint-ushort-explicit-checked-constant-0");
        }
        {
            const uint input = 1U;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "uint-ushort-explicit-checked-constant-2");
        }
        {
            const uint input = 65534U;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "uint-ushort-explicit-checked-constant-3");
        }
        {
            const uint input = 65535U;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "uint-ushort-explicit-checked-constant-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
