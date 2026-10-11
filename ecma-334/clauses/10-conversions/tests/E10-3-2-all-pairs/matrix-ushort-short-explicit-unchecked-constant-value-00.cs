/*
Rules: E10-3-2-all-pairs; E10-3-2-ushort; E12-23-numeric
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
            const ushort input = (ushort)(0);
            short result = unchecked((short)input);
            Check(result==(short)(0), "ushort-short-explicit-unchecked-constant-0");
        }
        {
            const ushort input = (ushort)(65535);
            short result = unchecked((short)input);
            Check(result==(short)(-1), "ushort-short-explicit-unchecked-constant-1");
        }
        {
            const ushort input = (ushort)(1);
            short result = unchecked((short)input);
            Check(result==(short)(1), "ushort-short-explicit-unchecked-constant-2");
        }
        {
            const ushort input = (ushort)(32766);
            short result = unchecked((short)input);
            Check(result==(short)(32766), "ushort-short-explicit-unchecked-constant-3");
        }
        {
            const ushort input = (ushort)(32767);
            short result = unchecked((short)input);
            Check(result==(short)(32767), "ushort-short-explicit-unchecked-constant-4");
        }
        {
            const ushort input = (ushort)(32768);
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "ushort-short-explicit-unchecked-constant-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
