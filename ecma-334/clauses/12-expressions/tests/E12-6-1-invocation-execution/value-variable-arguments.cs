/*
Rules: E12-6-1-invocation-execution; E12-6-1-invocation-arguments; E12-6-1-function-member-definition; E12-6-1-category-methods
Authority: ECMA-334 7th ed 12.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Touch(7, ref variable)
Into: Touch(8, ref variable)
*/
using System;
class Program
{
    static int checks, failures, calls;
    static int Touch(int value, ref int variable) { calls++; variable += value; return value * 3; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int variable = 11; int result = Touch(7, ref variable);
        Check(result == 21 && calls == 1, "function-member-executable-statements");
        Check(variable == 18, "function-member-value-and-variable-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
