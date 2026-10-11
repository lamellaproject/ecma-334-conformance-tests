/*
Rules: E8-4-3-closed-constructed-identity
Authority: ECMA-334 7th ed 8.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: typeof(Slot<long>)
Into: typeof(Slot<int>)
*/
using System;
class Slot<T> { }
class Other<T> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(typeof(Slot<int>) == typeof(Slot<System.Int32>) && typeof(Slot<int>) != typeof(Slot<long>) && typeof(Slot<int>) != typeof(Other<int>), "definition-and-arguments-determine-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
