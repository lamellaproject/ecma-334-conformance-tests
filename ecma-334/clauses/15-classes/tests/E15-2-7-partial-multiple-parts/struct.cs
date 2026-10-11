/*
Rules: E15-2-7-partial-multiple-parts
Authority: ECMA-334 7th ed 15.2.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: partial struct Packet { public int Read() { return Number + 3; } }
Into: partial struct Other { public int Read() { return 3; } }
*/
using System;
partial struct Packet { public int Number; }
partial struct Packet { public int Read() { return Number + 3; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Packet value = new Packet();
        value.Number = 47;
        Check(value.Read() == 50, "struct-parts-merge");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
