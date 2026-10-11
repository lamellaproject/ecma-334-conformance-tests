/*
Rules: E10-3-2-all-pairs; E10-3-2-ulong
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 6
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
            ulong input = 0UL;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "ulong-ushort-explicit-unchecked-variable-0");
        }
        {
            ulong input = 18446744073709551615UL;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "ulong-ushort-explicit-unchecked-variable-1");
        }
        {
            ulong input = 1UL;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "ulong-ushort-explicit-unchecked-variable-2");
        }
        {
            ulong input = 65534UL;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "ulong-ushort-explicit-unchecked-variable-3");
        }
        {
            ulong input = 65535UL;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "ulong-ushort-explicit-unchecked-variable-4");
        }
        {
            ulong input = 65536UL;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "ulong-ushort-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
