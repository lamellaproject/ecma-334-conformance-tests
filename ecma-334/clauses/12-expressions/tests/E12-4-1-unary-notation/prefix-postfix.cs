/*
Rules: E12-4-1-unary-notation; E12-4-1-unary-arity; E12-4-1-operator-application; E12-4-3-predefined-implementations
Authority: ECMA-334 7th ed 12.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int old = value++;
Into: int old = ++value;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 14; int old = value++;
        Check(old == 14 && value == 15, "postfix-unary-operand");
        Check(-value == -15 && !false && ~0 == -1, "prefix-unary-operand");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
