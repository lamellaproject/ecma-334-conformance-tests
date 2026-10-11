/*
Rules: E10-3-2-all-pairs; E10-3-2-uint
Authority: ECMA-334 7th ed 10.3.2
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
            uint input = 0U;
            short result = checked((short)input);
            Check(result==(short)(0), "uint-short-explicit-checked-variable-0");
        }
        {
            uint input = 1U;
            short result = checked((short)input);
            Check(result==(short)(1), "uint-short-explicit-checked-variable-2");
        }
        {
            uint input = 32766U;
            short result = checked((short)input);
            Check(result==(short)(32766), "uint-short-explicit-checked-variable-3");
        }
        {
            uint input = 32767U;
            short result = checked((short)input);
            Check(result==(short)(32767), "uint-short-explicit-checked-variable-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
