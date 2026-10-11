/*
Rules: E10-2-2-same; E12-23-numeric
Authority: ECMA-334 7th ed 10.2.2
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
            const ushort input = (ushort)(0);
            ushort result = checked(input);
            Check(result==(ushort)(0), "ushort-ushort-implicit-checked-constant-0");
        }
        {
            const ushort input = (ushort)(65535);
            ushort result = checked(input);
            Check(result==(ushort)(65535), "ushort-ushort-implicit-checked-constant-1");
        }
        {
            const ushort input = (ushort)(1);
            ushort result = checked(input);
            Check(result==(ushort)(1), "ushort-ushort-implicit-checked-constant-2");
        }
        {
            const ushort input = (ushort)(65534);
            ushort result = checked(input);
            Check(result==(ushort)(65534), "ushort-ushort-implicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
