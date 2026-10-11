/*
Rules: E12-8-9-3-extension-fallback; E12-8-9-2-empty-extension-fallback; E12-8-9-3-static-rewrite; E12-8-9-3-eligible-class; E12-8-9-3-eligible-nonnested-class; E12-8-9-3-eligible-nongeneric-class; E12-8-9-3-eligible-name; E12-8-9-3-eligible-applicable; E12-8-9-3-selected-class; E12-8-9-3-static-invocation
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: receiver.Choose<int>(Argument())
Into: receiver.Choose<int>(9)
*/
using System;
class Cell { public int Choose(string text) { return -1; } }
static class Extensions
{
    public static int Choose<T>(this Cell receiver, int value) { Program.trace += "M"; return value + 3; }
    public static int Choose(this Cell receiver) { return receiver == null ? 7 : 8; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static int Argument() { trace += "A"; return 5; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell receiver = new Cell();
        Check(receiver.Choose<int>(Argument()) == 8 && trace == "AM", "explicit-extension-rewrite-preserves-type-and-value-arguments");
        Check(receiver.Choose() == 8, "empty-extension-arguments-after-inapplicable-instance");
        receiver = null;
        Check(receiver.Choose() == 7, "static-extension-receives-null-without-instance-null-check");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
