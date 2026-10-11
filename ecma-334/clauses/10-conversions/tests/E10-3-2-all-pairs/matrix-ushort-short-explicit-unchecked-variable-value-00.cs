/*
Rules: E10-3-2-all-pairs; E10-3-2-ushort
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
            ushort input = (ushort)(0);
            short result = unchecked((short)input);
            Check(result==(short)(0), "ushort-short-explicit-unchecked-variable-0");
        }
        {
            ushort input = (ushort)(65535);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "ushort-short-explicit-unchecked-variable-1");
        }
        {
            ushort input = (ushort)(1);
            short result = unchecked((short)input);
            Check(result==(short)(1), "ushort-short-explicit-unchecked-variable-2");
        }
        {
            ushort input = (ushort)(32766);
            short result = unchecked((short)input);
            Check(result==(short)(32766), "ushort-short-explicit-unchecked-variable-3");
        }
        {
            ushort input = (ushort)(32767);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "ushort-short-explicit-unchecked-variable-4");
        }
        {
            ushort input = (ushort)(32768);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "ushort-short-explicit-unchecked-variable-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
