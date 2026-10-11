/*
Rules: E10-3-2-all-pairs; E10-3-2-decimal
Authority: ECMA-334 7th ed 10.3.2
Version: 7.3
Expected: run
Stdout: OK 10
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
            decimal input = 0m;
            uint result = unchecked((uint)input);
            Check(result==0U, "decimal-uint-explicit-unchecked-variable-2");
        }
        {
            decimal input = 1m;
            uint result = unchecked((uint)input);
            Check(result==1U, "decimal-uint-explicit-unchecked-variable-3");
        }
        {
            decimal input = 0.1m;
            uint result = unchecked((uint)input);
            Check(result==0U, "decimal-uint-explicit-unchecked-variable-5");
        }
        {
            decimal input = -0.1m;
            uint result = unchecked((uint)input);
            Check(result==0U, "decimal-uint-explicit-unchecked-variable-6");
        }
        {
            decimal input = 1E-28m;
            uint result = unchecked((uint)input);
            Check(result==0U, "decimal-uint-explicit-unchecked-variable-7");
        }
        {
            decimal input = -1E-28m;
            uint result = unchecked((uint)input);
            Check(result==0U, "decimal-uint-explicit-unchecked-variable-8");
        }
        {
            decimal input = 4294967294m;
            uint result = unchecked((uint)input);
            Check(result==4294967294U, "decimal-uint-explicit-unchecked-variable-9");
        }
        {
            decimal input = 4294967295m;
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "decimal-uint-explicit-unchecked-variable-10");
        }
        {
            decimal input = -0.75m;
            uint result = unchecked((uint)input);
            Check(result==0U, "decimal-uint-explicit-unchecked-variable-12");
        }
        {
            decimal input = 4294967295.75m;
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "decimal-uint-explicit-unchecked-variable-13");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
