/*
Rules: E10-3-2-all-pairs; E10-3-2-short; E12-23-numeric
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
            const short input = (short)(-32768);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "short-sbyte-explicit-unchecked-constant-0");
        }
        {
            const short input = (short)(32767);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "short-sbyte-explicit-unchecked-constant-1");
        }
        {
            const short input = (short)(0);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "short-sbyte-explicit-unchecked-constant-2");
        }
        {
            const short input = (short)(1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "short-sbyte-explicit-unchecked-constant-3");
        }
        {
            const short input = (short)(-1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "short-sbyte-explicit-unchecked-constant-4");
        }
        {
            const short input = (short)(-129);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "short-sbyte-explicit-unchecked-constant-5");
        }
        {
            const short input = (short)(-128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "short-sbyte-explicit-unchecked-constant-6");
        }
        {
            const short input = (short)(-127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-127), "short-sbyte-explicit-unchecked-constant-7");
        }
        {
            const short input = (short)(126);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "short-sbyte-explicit-unchecked-constant-8");
        }
        {
            const short input = (short)(127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "short-sbyte-explicit-unchecked-constant-9");
        }
        {
            const short input = (short)(128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "short-sbyte-explicit-unchecked-constant-10");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
