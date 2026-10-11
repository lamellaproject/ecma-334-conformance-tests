/*
Rules: E12-3-1-dynamic-runtime-type; E12-3-1-dynamic-type; E12-3-1-dynamic-operation; E12-3-1-binds-method-invocation; E12-3-2-dynamic-time; E12-3-4-dynamic-subexpression-type
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: dynamic argument = 18;
Into: object argument = 18;
*/
using System;
class Program
{
    static int checks, failures;
    public static int Choose(int value) { return 1; }
    public static int Choose(string value) { return 2; }
    public static int Choose(object value) { return 3; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = 18;
        int first = Choose(argument);
        argument = "blue";
        int second = Choose(argument);
        Check(first == 1, "runtime-int-overload");
        Check(second == 2, "runtime-string-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
