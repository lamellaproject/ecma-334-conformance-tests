/*
Rules: E15-2-5-base-array
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Reader : Basis<int[]>
Into: class Reader : Basis<object>
*/
using System;
abstract class Basis<A> { public abstract int Read<T>(T value) where T : A; }
class Reader : Basis<int[]>
{
    static int Pick(object value) { return 1; }
    static int Pick(Array value) { return 2; }
    public override int Read<T>(T value) { return Pick(value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Reader().Read(new int[] { 229 }) == 2, "substituted-array-constraint-has-array-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
