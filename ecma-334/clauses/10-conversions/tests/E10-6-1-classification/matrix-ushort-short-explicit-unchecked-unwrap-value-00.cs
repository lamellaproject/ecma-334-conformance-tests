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
            ushort? input = (ushort)(0);
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-ushort-short-explicit-unchecked-unwrap-0");
        }
        {
            ushort? input = (ushort)(65535);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nullable-ushort-short-explicit-unchecked-unwrap-1");
        }
        {
            ushort? input = (ushort)(1);
            short result = unchecked((short)input);
            Check(result==(short)(1), "nullable-ushort-short-explicit-unchecked-unwrap-2");
        }
        {
            ushort? input = (ushort)(32766);
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nullable-ushort-short-explicit-unchecked-unwrap-3");
        }
        {
            ushort? input = (ushort)(32767);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-ushort-short-explicit-unchecked-unwrap-4");
        }
        {
            ushort? input = (ushort)(32768);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-ushort-short-explicit-unchecked-unwrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
