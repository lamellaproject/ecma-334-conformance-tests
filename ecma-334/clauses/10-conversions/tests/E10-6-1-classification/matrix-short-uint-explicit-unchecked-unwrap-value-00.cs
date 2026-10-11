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
            short? input = (short)(-32768);
            uint result = unchecked((uint)input);
            Check(result==4294934528U, "nullable-short-uint-explicit-unchecked-unwrap-0");
        }
        {
            short? input = (short)(32767);
            uint result = unchecked((uint)input);
            Check(result==32767U, "nullable-short-uint-explicit-unchecked-unwrap-1");
        }
        {
            short? input = (short)(0);
            uint result = unchecked((uint)input);
            Check(result==0U, "nullable-short-uint-explicit-unchecked-unwrap-2");
        }
        {
            short? input = (short)(1);
            uint result = unchecked((uint)input);
            Check(result==1U, "nullable-short-uint-explicit-unchecked-unwrap-3");
        }
        {
            short? input = (short)(-1);
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "nullable-short-uint-explicit-unchecked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
