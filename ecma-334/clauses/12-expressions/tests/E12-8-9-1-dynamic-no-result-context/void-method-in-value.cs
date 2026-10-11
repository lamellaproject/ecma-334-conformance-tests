/*
Rules: E12-8-9-1-dynamic-no-result-context
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public void Touch() { Program.calls++; }
Into: public int Touch() { Program.calls++; return 3; }
*/
using System;
public class Cell { public void Touch() { Program.calls++; } }
public class Program
{
    public static int calls;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new Cell();
        bool rejected = false;
        try { object result = receiver.Touch(); }
        catch (Exception) { rejected = true; }
        Check(rejected, "void-dynamic-call-in-value-context-binding-error");
        Check(calls == 0, "void-result-error-prevents-body-execution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
