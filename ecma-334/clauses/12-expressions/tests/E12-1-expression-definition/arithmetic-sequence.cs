/*
Rules: E12-1-expression-definition
Authority: ECMA-334 7th ed 12.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left * right + tail
Into: left * right - tail
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left = 7, right = 3, tail = 5;
        int result = left * right + tail;
        Check(result == 26, "operator-operand-sequence");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
