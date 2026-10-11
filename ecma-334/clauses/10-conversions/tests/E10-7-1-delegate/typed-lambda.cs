/*
Rules: E10-7-1-delegate; E10-7-1-typed; E10-7-1-value-expression
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (int input) => input + 2
Into: (int input) => 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<int, int> converted = (int input) => input + 2;
        Check(converted(61) == 63, "typed-lambda/returned-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
