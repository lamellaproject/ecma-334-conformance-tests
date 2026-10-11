/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            long? input = long.MinValue;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nullable-long-ushort-explicit-unchecked-unwrap-0");
        }
        {
            long? input = 9223372036854775807L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nullable-long-ushort-explicit-unchecked-unwrap-1");
        }
        {
            long? input = 0L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nullable-long-ushort-explicit-unchecked-unwrap-2");
        }
        {
            long? input = 1L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "nullable-long-ushort-explicit-unchecked-unwrap-3");
        }
        {
            long? input = -1L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nullable-long-ushort-explicit-unchecked-unwrap-4");
        }
        {
            long? input = 65534L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "nullable-long-ushort-explicit-unchecked-unwrap-5");
        }
        {
            long? input = 65535L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nullable-long-ushort-explicit-unchecked-unwrap-6");
        }
        {
            long? input = 65536L;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nullable-long-ushort-explicit-unchecked-unwrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
