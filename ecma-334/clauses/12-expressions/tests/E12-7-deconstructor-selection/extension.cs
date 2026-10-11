/*
Rules: E12-7-deconstructor-selection; E12-7-deconstructor-call; E12-7-deconstructor-result
Authority: ECMA-334 7th ed 12.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (first, second) = source;
Into: (first, second) = (3, 8);
*/
using System;
class Pair { public int calls; }
static class PairExtensions
{
    public static void Deconstruct(this Pair receiver, out int first, out int second)
    { receiver.calls++; first = 3; second = 8; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair source = new Pair();
        int first = 0, second = 0;
        (first, second) = source;
        Check(source.calls == 1, "unique-extension-deconstructor-called-once");
        Check(first == 3 && second == 8, "extension-deconstructor-out-values-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
