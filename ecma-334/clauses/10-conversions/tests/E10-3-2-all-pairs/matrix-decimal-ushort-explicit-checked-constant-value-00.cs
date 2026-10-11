/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
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
            const decimal input = 0m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-constant-2");
        }
        {
            const decimal input = 1m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "decimal-ushort-explicit-checked-constant-3");
        }
        {
            const decimal input = 0.1m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-constant-5");
        }
        {
            const decimal input = 1E-28m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "decimal-ushort-explicit-checked-constant-7");
        }
        {
            const decimal input = 65534m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "decimal-ushort-explicit-checked-constant-9");
        }
        {
            const decimal input = 65535m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "decimal-ushort-explicit-checked-constant-10");
        }
        {
            const decimal input = 65535.75m;
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "decimal-ushort-explicit-checked-constant-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
