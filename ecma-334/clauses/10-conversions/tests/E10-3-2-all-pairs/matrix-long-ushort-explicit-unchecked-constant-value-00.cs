/*
Rules: E10-3-2-all-pairs; E10-3-2-long; E12-23-numeric
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 8
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
            const long input = long.MinValue;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "long-ushort-explicit-unchecked-constant-0");
        }
        {
            const long input = 9223372036854775807L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "long-ushort-explicit-unchecked-constant-1");
        }
        {
            const long input = 0L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "long-ushort-explicit-unchecked-constant-2");
        }
        {
            const long input = 1L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "long-ushort-explicit-unchecked-constant-3");
        }
        {
            const long input = -1L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "long-ushort-explicit-unchecked-constant-4");
        }
        {
            const long input = 65534L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "long-ushort-explicit-unchecked-constant-5");
        }
        {
            const long input = 65535L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "long-ushort-explicit-unchecked-constant-6");
        }
        {
            const long input = 65536L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "long-ushort-explicit-unchecked-constant-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
