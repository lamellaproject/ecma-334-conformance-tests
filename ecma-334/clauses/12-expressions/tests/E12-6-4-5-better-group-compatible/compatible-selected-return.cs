/*
Rules: E12-6-4-5-better-group-compatible
Authority: ECMA-334 7th ed 12.6.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Pick(Echo)
Into: Pick(Text)
*/
using System;
class Program
{
    static int checks, failures;
    static int Echo(int x) { return x; }
    static string Echo(object x) { return "x"; }
    static string Text(int x) { return "x"; }
    static int Pick(Func<int, int> f) { return 1; }
    static int Pick(Func<int, object> f) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pick(Echo) == 1, "selected-int-return-compatible-only-with-int-return-delegate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
