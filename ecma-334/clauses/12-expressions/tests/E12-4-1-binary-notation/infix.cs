/*
Rules: E12-4-1-binary-notation; E12-4-1-binary-arity
Authority: ECMA-334 7th ed 12.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left - right
Into: right - left
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left = 17, right = 4;
        int result = left - right;
        Check(result == 13, "infix-two-operands");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
