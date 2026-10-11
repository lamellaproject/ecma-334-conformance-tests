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
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nullable-ushort-ushort-explicit-unchecked-unwrap-0");
        }
        {
            ushort? input = (ushort)(65535);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nullable-ushort-ushort-explicit-unchecked-unwrap-1");
        }
        {
            ushort? input = (ushort)(1);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "nullable-ushort-ushort-explicit-unchecked-unwrap-2");
        }
        {
            ushort? input = (ushort)(65534);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "nullable-ushort-ushort-explicit-unchecked-unwrap-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
