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
            int? input = -2147483648;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nullable-int-byte-explicit-unchecked-unwrap-0");
        }
        {
            int? input = 2147483647;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nullable-int-byte-explicit-unchecked-unwrap-1");
        }
        {
            int? input = 0;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nullable-int-byte-explicit-unchecked-unwrap-2");
        }
        {
            int? input = 1;
            byte result = unchecked((byte)input);
            Check(result==(byte)(1), "nullable-int-byte-explicit-unchecked-unwrap-3");
        }
        {
            int? input = -1;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nullable-int-byte-explicit-unchecked-unwrap-4");
        }
        {
            int? input = 254;
            byte result = unchecked((byte)input);
            Check(result==(byte)(254), "nullable-int-byte-explicit-unchecked-unwrap-5");
        }
        {
            int? input = 255;
            byte result = unchecked((byte)input);
            Check(result==(byte)(255), "nullable-int-byte-explicit-unchecked-unwrap-6");
        }
        {
            int? input = 256;
            byte result = unchecked((byte)input);
            Check(result==(byte)(0), "nullable-int-byte-explicit-unchecked-unwrap-7");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
