/*
Rules: E10-3-2-all-pairs; E10-3-2-int; E12-23-numeric
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
            const int input = 0;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "int-ushort-explicit-checked-constant-2");
        }
        {
            const int input = 1;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "int-ushort-explicit-checked-constant-3");
        }
        {
            const int input = 65534;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "int-ushort-explicit-checked-constant-5");
        }
        {
            const int input = 65535;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "int-ushort-explicit-checked-constant-6");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
