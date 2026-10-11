/*
Rules: E9-6-ushort-read-atomic; E9-6-ushort-write-atomic
Authority: ECMA-334 7th ed 9.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: shared = Second;
Into: shared = Third;
*/
using System;
using System.Threading;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    const ushort First = 0x55AA, Second = 0xAA55, Third = 0;
    static ushort shared = First;
    static void Write()
    {
        for (int i = 0; i < 200000; i++) { shared = First; shared = Second; }
    }
    static void Main()
    {
        Thread writer = new Thread(Write);
        writer.Start();
        bool valid = true;
        for (int i = 0; i < 200000; i++)
        {
            ushort observed = shared;
            if (observed != First && observed != Second) valid = false;
        }
        writer.Join();
        Check(valid, "ushort-reads-observe-only-whole-written-values");
        Check(shared == First || shared == Second, "ushort-final-write-is-whole");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
