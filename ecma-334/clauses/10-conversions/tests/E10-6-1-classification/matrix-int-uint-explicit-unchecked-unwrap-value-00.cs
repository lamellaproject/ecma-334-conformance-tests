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
            int? input = -2147483648;
            uint result = unchecked((uint)input);
            Check(result==2147483648U, "nullable-int-uint-explicit-unchecked-unwrap-0");
        }
        {
            int? input = 2147483647;
            uint result = unchecked((uint)input);
            Check(result==2147483647U, "nullable-int-uint-explicit-unchecked-unwrap-1");
        }
        {
            int? input = 0;
            uint result = unchecked((uint)input);
            Check(result==0U, "nullable-int-uint-explicit-unchecked-unwrap-2");
        }
        {
            int? input = 1;
            uint result = unchecked((uint)input);
            Check(result==1U, "nullable-int-uint-explicit-unchecked-unwrap-3");
        }
        {
            int? input = -1;
            uint result = unchecked((uint)input);
            Check(result==4294967295U, "nullable-int-uint-explicit-unchecked-unwrap-4");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
