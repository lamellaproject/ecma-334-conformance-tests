/*
Rules: E12-8-9-1-ref-result; E12-8-9-1-ref-result-type
Authority: ECMA-334 7th ed 12.8.9.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Slot() = 19;
Into: Slot() = 23;
*/
using System;
delegate ref int Location();
class Program
{
    static int checks, failures;
    static int storage;
    static ref int Slot() { return ref storage; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Slot() = 19;
        Check(storage == 19, "ref-method-invocation-is-int-variable");
        Location locator = Slot;
        ref int alias = ref locator();
        alias = 29;
        Check(storage == 29, "ref-delegate-invocation-aliases-return-location");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
