/*
Rules: E20-6-shared-ref-variable; E20-6-ref-changes-visible
Authority: ECMA-334 7th ed 20.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Edit composed = first + second;
Into: Edit composed = second;
*/
using System;
delegate void Edit(ref int value);
class Program
{
    static int checks, failures;
    static int stored = 5;
    static void A(ref int value)
    {
        value = 13;
        Check(stored == 13, "first-target-live-alias");
    }
    static void B(ref int value)
    {
        Check(value == 13 && stored == 13, "prior-reference-change-visible");
        value = 17;
        Check(stored == 17, "second-target-same-live-alias");
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Edit first = A, second = B;
        Edit composed = first + second;
        composed(ref stored);
        Check(stored == 17, "caller-variable-retains-last-reference-change");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
