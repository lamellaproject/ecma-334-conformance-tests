/*
Rules: E10-7-1-delegate; E10-3-1-includes-implicit; E10-2-15-delegate
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (Action)(() => observed = 47)
Into: (Action)(() => observed = 0)
*/
using System;
class Program
{
    static int checks, failures;
    static int observed;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Action converted = (Action)(() => observed = 47);
        converted();
        Check(observed == 47, "explicit-lambda-action/invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
