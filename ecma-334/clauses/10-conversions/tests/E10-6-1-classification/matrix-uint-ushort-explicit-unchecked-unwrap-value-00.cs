/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
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
            uint? input = 0U;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nullable-uint-ushort-explicit-unchecked-unwrap-0");
        }
        {
            uint? input = 4294967295U;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nullable-uint-ushort-explicit-unchecked-unwrap-1");
        }
        {
            uint? input = 1U;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "nullable-uint-ushort-explicit-unchecked-unwrap-2");
        }
        {
            uint? input = 65534U;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65534), "nullable-uint-ushort-explicit-unchecked-unwrap-3");
        }
        {
            uint? input = 65535U;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nullable-uint-ushort-explicit-unchecked-unwrap-4");
        }
        {
            uint? input = 65536U;
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nullable-uint-ushort-explicit-unchecked-unwrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
