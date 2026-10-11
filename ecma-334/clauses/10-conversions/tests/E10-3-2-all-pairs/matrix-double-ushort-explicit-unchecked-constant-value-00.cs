/*
Rules: E10-3-2-all-pairs; E10-3-2-double; E12-23-numeric
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
            const double input = 0.0d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "double-ushort-explicit-unchecked-constant-2");
        }
        {
            const double input = -0.0d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "double-ushort-explicit-unchecked-constant-3");
        }
        {
            const double input = 1.0d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "double-ushort-explicit-unchecked-constant-4");
        }
        {
            const double input = 0.75d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "double-ushort-explicit-unchecked-constant-6");
        }
        {
            const double input = -0.75d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "double-ushort-explicit-unchecked-constant-7");
        }
        {
            const double input = 65534.0d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "double-ushort-explicit-unchecked-constant-11");
        }
        {
            const double input = 65535.0d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "double-ushort-explicit-unchecked-constant-12");
        }
        {
            const double input = 65535.75d;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "double-ushort-explicit-unchecked-constant-14");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
