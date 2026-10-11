/*
Rules: E15-11-4-field-initialized-before-instance-access; E15-11-4-field-initializer-assignments-before-base
Authority: ECMA-334 7th ed 15.11.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int First = 13; int Second = 19; public Gauge() { First = 3; }
Into: int First; int Second; public Gauge() { First = 13; Second = 19; First = 3; }
*/
using System;
abstract class Basis
{
    public int Snapshot;
    public Basis() { Snapshot = Read(); }
    public abstract int Read();
}
class Gauge : Basis
{
    int First = 13; int Second = 19; public Gauge() { First = 3; }
    public override int Read() { return First + Second; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        Check(item.Snapshot == 32, "base-virtual-call-observes-initialized-fields");
        Check(item.Read() == 22, "derived-constructor-body-runs-after-base-snapshot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
