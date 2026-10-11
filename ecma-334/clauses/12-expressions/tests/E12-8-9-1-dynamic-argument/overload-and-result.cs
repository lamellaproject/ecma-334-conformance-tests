/*
Rules: E12-8-9-1-dynamic-argument; E12-8-9-1-dynamic-value; E12-8-9-1-dynamic-runtime-types; E12-8-9-1-dynamic-limited-check
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Choose(argument)
Into: Choose((object)argument)
*/
using System;
class Program
{
    static int checks, failures;
    static string Choose(string value) { return "string"; }
    static string Choose(object value) { return "object"; }
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = "spruce";
        var result = Choose(argument);
        Check(result == "string", "runtime-argument-type-selects-overload");
        object boxed = result;
        Check(Kind(result) == 1 && Kind(boxed) == 2, "dynamic-result-retains-dynamic-classification");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
