/*
Rules: E8-2-2-class-indexer-members
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return index + 8;
Into: return index + 9;
*/
using System;
class Device { public int this[int index] { get { return index + 8; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Device device = new Device();
        Check(device[4] == 12, "class-indexer-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
