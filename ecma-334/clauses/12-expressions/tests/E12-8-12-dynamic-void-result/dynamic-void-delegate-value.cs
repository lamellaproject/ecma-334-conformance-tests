/*
Rules: E12-8-12-dynamic-void-result
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: dynamic receiver = new Action[] { Touch };
Into: dynamic receiver = new Func<int>[] { Number };
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Touch() { calls++; }
    static int Number() { calls++; return 3; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new Action[] { Touch };
        bool rejected = false;
        try { object result = receiver?[0](); }
        catch (Exception) { rejected = true; }
        Check(rejected, "dynamic-void-element-invocation-rejected-in-value-context");
        Check(calls == 0, "void-result-error-prevents-delegate-execution");
        receiver = null;
        object absent = receiver?[0]();
        Check(absent == null, "null-dynamic-element-receiver-skips-void-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
