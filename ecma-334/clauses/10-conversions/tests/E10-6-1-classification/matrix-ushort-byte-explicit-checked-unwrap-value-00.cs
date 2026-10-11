/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            ushort? input = (ushort)(0);
            byte result = checked((byte)input);
            Check(result==(byte)(0), "nullable-ushort-byte-explicit-checked-unwrap-0");
        }
        {
            ushort? input = (ushort)(1);
            byte result = checked((byte)input);
            Check(result==(byte)(1), "nullable-ushort-byte-explicit-checked-unwrap-2");
        }
        {
            ushort? input = (ushort)(254);
            byte result = checked((byte)input);
            Check(result==(byte)(254), "nullable-ushort-byte-explicit-checked-unwrap-3");
        }
        {
            ushort? input = (ushort)(255);
            byte result = checked((byte)input);
            Check(result==(byte)(255), "nullable-ushort-byte-explicit-checked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
