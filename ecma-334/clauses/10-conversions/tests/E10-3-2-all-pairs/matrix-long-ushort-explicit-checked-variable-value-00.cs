/*
Rules: E10-3-2-all-pairs; E10-3-2-long
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
            long input = 0L;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "long-ushort-explicit-checked-variable-2");
        }
        {
            long input = 1L;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "long-ushort-explicit-checked-variable-3");
        }
        {
            long input = 65534L;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "long-ushort-explicit-checked-variable-5");
        }
        {
            long input = 65535L;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "long-ushort-explicit-checked-variable-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
