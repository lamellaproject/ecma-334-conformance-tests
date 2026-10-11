/*
Rules: E10-3-2-all-pairs; E10-3-2-char; E12-23-numeric
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
            const char input = (char)(0);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "char-ushort-explicit-checked-constant-0");
        }
        {
            const char input = (char)(65535);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65535), "char-ushort-explicit-checked-constant-1");
        }
        {
            const char input = (char)(1);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "char-ushort-explicit-checked-constant-2");
        }
        {
            const char input = (char)(65534);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(65534), "char-ushort-explicit-checked-constant-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
