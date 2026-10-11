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
            char? input = (char)(0);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(0), "nullable-char-sbyte-explicit-unchecked-unwrap-0");
        }
        {
            char? input = (char)(65535);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-1), "nullable-char-sbyte-explicit-unchecked-unwrap-1");
        }
        {
            char? input = (char)(1);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(1), "nullable-char-sbyte-explicit-unchecked-unwrap-2");
        }
        {
            char? input = (char)(126);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(126), "nullable-char-sbyte-explicit-unchecked-unwrap-3");
        }
        {
            char? input = (char)(127);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(127), "nullable-char-sbyte-explicit-unchecked-unwrap-4");
        }
        {
            char? input = (char)(128);
            sbyte result = unchecked((sbyte)input);
            Check(result==(sbyte)(-128), "nullable-char-sbyte-explicit-unchecked-unwrap-5");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
