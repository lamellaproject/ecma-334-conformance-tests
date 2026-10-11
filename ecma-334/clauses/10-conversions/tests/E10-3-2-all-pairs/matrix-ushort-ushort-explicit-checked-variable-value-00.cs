/*
Rules: E10-3-2-all-pairs
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
            ushort input = (ushort)(0);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "ushort-ushort-explicit-checked-variable-0");
        }
        {
            ushort input = (ushort)(65535);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "ushort-ushort-explicit-checked-variable-1");
        }
        {
            ushort input = (ushort)(1);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "ushort-ushort-explicit-checked-variable-2");
        }
        {
            ushort input = (ushort)(65534);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "ushort-ushort-explicit-checked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
