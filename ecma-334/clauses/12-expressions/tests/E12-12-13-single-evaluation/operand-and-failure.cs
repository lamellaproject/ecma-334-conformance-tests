/*
Rules: E12-12-13-single-evaluation; E12-12-13-static-result; E12-12-13-no-conversion-exception; E12-12-13-failed-conversion-null
Authority: ECMA-334 7th ed 12.12.13
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Target first = Get(source) as Target;
Into: Target first = Get(Get(source)) as Target;
*/
using System;
class Target { }
class Program
{
    static int calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static object Get(object value) { calls++; return value; }
    static void Main()
    {
        object source = new Target(); Target first = Get(source) as Target;
        Check((object)first == source && calls == 1, "success-evaluates-once-and-preserves-identity");
        source = new object(); Target failed = null; bool threw = false;
        try { failed = Get(source) as Target; } catch (Exception) { threw = true; }
        Check(!threw && failed == null && calls == 2, "failed-conversion-null-without-exception");
        source = null; failed = Get(source) as Target;
        Check(failed == null && calls == 3, "null-evaluates-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
