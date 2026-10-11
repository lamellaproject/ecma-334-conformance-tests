/*
Rules: E12-7-deconstructor-selection; E12-7-deconstructor-call; E12-7-deconstructor-result; E12-7-temporaries
Authority: ECMA-334 7th ed 12.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (first, second) = source;
Into: (first, second) = (3, 8);
*/
using System;
class Pair
{
    public int calls;
    public void Deconstruct(out int first, out int second) { calls++; first = 3; second = 8; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pair source = new Pair();
        int first = 0, second = 0, __v1 = 91, __v2 = 92;
        (first, second) = source;
        Check(source.calls == 1, "unique-instance-deconstructor-called-once");
        Check(first == 3 && second == 8, "deconstructor-out-values-are-assignment-results");
        Check(__v1 == 91 && __v2 == 92, "out-temporaries-do-not-reuse-user-locals");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
