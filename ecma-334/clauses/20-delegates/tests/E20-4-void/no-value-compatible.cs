/*
Rules: E20-4-void; E20-2-returns-no-value; E20-5-conversion-creation
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: delegate void Notice();
Into: delegate int Notice();
*/
using System;
delegate void Notice();
class Program
{
    static int checks, failures;
    static int calls;
    static void Touch() { calls++; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Notice direct = Touch;
        Notice wrapped = new Notice(direct);
        direct();
        Check(calls == 1, "void-method-compatible");
        wrapped();
        Check(calls == 2, "void-delegate-compatible");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
