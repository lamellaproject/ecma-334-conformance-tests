/*
Rules: E10-6-1-classification; E10-6-1-unwrap
Authority: ECMA-334 7th ed 10.6.1
Version: 7.3
Expected: run
Stdout: OK 5
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
            sbyte? input = (sbyte)(-128);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65408), "nullable-sbyte-ushort-explicit-unchecked-unwrap-0");
        }
        {
            sbyte? input = (sbyte)(127);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(127), "nullable-sbyte-ushort-explicit-unchecked-unwrap-1");
        }
        {
            sbyte? input = (sbyte)(0);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(0), "nullable-sbyte-ushort-explicit-unchecked-unwrap-2");
        }
        {
            sbyte? input = (sbyte)(1);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(1), "nullable-sbyte-ushort-explicit-unchecked-unwrap-3");
        }
        {
            sbyte? input = (sbyte)(-1);
            ushort result = unchecked((ushort)input);
            Check(result==(ushort)(65535), "nullable-sbyte-ushort-explicit-unchecked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
