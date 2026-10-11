/*
Rules: E10-7-1-delegate; E10-3-1-includes-implicit; E10-2-15-delegate
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (Func<int,int>)(x => x + 7)
Into: (Func<int,int>)(x => x)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<int,int> converted = (Func<int,int>)(x => x + 7);
        Check(converted(31) == 38, "explicit-lambda-cast/invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
