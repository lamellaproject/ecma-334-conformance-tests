/*
Rules: E13-5-goto-label-reachability
Authority: ECMA-334 7th ed 13.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: finally { throw marker; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures;
    static Exception marker = new Exception();
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Transfer()
    {
        try { goto target; } finally { throw marker; }
        target: Console.WriteLine("FAIL unreachable-target");
    }
    static void Main()
    {
        bool same = false;
        try { Transfer(); } catch (Exception e) { same = object.ReferenceEquals(e, marker); }
        Check(same, "finally-blocks-target-and-value-endpoint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
