/*
Rules: E10-3-2-all-pairs; E10-3-2-short
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 3
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
            short input = (short)(32767);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(32767), "short-ushort-explicit-checked-variable-1");
        }
        {
            short input = (short)(0);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(0), "short-ushort-explicit-checked-variable-2");
        }
        {
            short input = (short)(1);
            ushort result = checked((ushort)input);
            Check(result==(ushort)(1), "short-ushort-explicit-checked-variable-3");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
