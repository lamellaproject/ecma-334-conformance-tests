/*
Rules: E10-3-2-all-pairs; E10-3-2-short
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 11
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
            short input = (short)(-32768);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "short-sbyte-explicit-unchecked-variable-0");
        }
        {
            short input = (short)(32767);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "short-sbyte-explicit-unchecked-variable-1");
        }
        {
            short input = (short)(0);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "short-sbyte-explicit-unchecked-variable-2");
        }
        {
            short input = (short)(1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "short-sbyte-explicit-unchecked-variable-3");
        }
        {
            short input = (short)(-1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "short-sbyte-explicit-unchecked-variable-4");
        }
        {
            short input = (short)(-129);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "short-sbyte-explicit-unchecked-variable-5");
        }
        {
            short input = (short)(-128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "short-sbyte-explicit-unchecked-variable-6");
        }
        {
            short input = (short)(-127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "short-sbyte-explicit-unchecked-variable-7");
        }
        {
            short input = (short)(126);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "short-sbyte-explicit-unchecked-variable-8");
        }
        {
            short input = (short)(127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "short-sbyte-explicit-unchecked-variable-9");
        }
        {
            short input = (short)(128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "short-sbyte-explicit-unchecked-variable-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
