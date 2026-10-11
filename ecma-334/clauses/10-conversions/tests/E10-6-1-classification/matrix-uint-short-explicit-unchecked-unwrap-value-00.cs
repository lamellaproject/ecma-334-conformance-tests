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
            short result = unchecked((short)input);
            Check(result==(short)(0), "nullable-uint-short-explicit-unchecked-unwrap-0");
        }
        {
            uint? input = 4294967295U;
            short result = unchecked((short)input);
            Check(result==(short)(-1), "nullable-uint-short-explicit-unchecked-unwrap-1");
        }
        {
            uint? input = 1U;
            short result = unchecked((short)input);
            Check(result==(short)(1), "nullable-uint-short-explicit-unchecked-unwrap-2");
        }
        {
            uint? input = 32766U;
            short result = unchecked((short)input);
            Check(result==(short)(32766), "nullable-uint-short-explicit-unchecked-unwrap-3");
        }
        {
            uint? input = 32767U;
            short result = unchecked((short)input);
            Check(result==(short)(32767), "nullable-uint-short-explicit-unchecked-unwrap-4");
        }
        {
            uint? input = 32768U;
            short result = unchecked((short)input);
            Check(result==(short)(-32768), "nullable-uint-short-explicit-unchecked-unwrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
