/*
Rules: E15-2-5-erase-dynamic; E15-2-5-interface-erasure
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : IReading<A>
Into: 
*/
using System;
interface IReading<A> { A Read(); }
class Record : IReading<object> { public object Read() { return 211; } }
abstract class Basis<A> { public abstract int Read<T>(T value) where T : IReading<A>; }
class Reader : Basis<dynamic>
{
    static int Pick(object value) { return 1; }
    static int Pick(int value) { return 2; }
    public override int Read<T>(T value) { return Pick(value.Read()); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Reader().Read(new Record()) == 1, "dynamic-leaf-erased-to-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
