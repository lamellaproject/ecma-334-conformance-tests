/*
Rules: E12-8-16-1-new-instance; E12-8-16-1-object-forms; E12-8-16-2-create-instance; E12-8-16-2-class-allocation
Authority: ECMA-334 7th ed 12.8.16.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Marker second = new Marker();
Into: Marker second = first;
*/
using System;
class Marker { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Marker first = new Marker();
        Marker second = new Marker();
        first.Value = 37;
        Check(first != null && second != null, "new-class-nonnull");
        Check(!object.ReferenceEquals(first, second), "new-class-distinct-identity");
        Check(second.Value == 0, "new-class-independent-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
