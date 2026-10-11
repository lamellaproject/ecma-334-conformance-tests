/*
Rules: E15-2-5-erase-generic; E15-2-5-base-class
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Reader : Basis<View<dynamic>>
Into: class Reader : Basis<object>
*/
using System;
class View<A> { public A Value; }
abstract class Basis<A> { public abstract int Read<T>(T value) where T : A; }
class Reader : Basis<View<dynamic>>
{
    static int Pick(object value) { return 1; }
    static int Pick(int value) { return 2; }
    public override int Read<T>(T value) { return Pick(value.Value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Reader().Read(new View<dynamic> { Value = 197 }) == 1, "effective-class-erases-generic-dynamic-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
