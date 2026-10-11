/*
Rules: E10-8-generic-inferred; E10-8-generic-runtime
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Func<int,int> converted = Generic.Echo;
Into: Func<int,int> converted = x => 0;
*/
using System;
static class Generic { public static T Echo<T>(T value) { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<int,int> converted = Generic.Echo;
        Check(converted(43) == 43, "inferred-method-group/invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
