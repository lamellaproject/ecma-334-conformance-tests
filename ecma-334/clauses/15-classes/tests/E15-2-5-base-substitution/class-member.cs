/*
Rules: E15-2-5-base-substitution; E15-2-5-base-class
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Reader : Basis<Record>
Into: class Reader : Basis<object>
*/
using System;
class Record { public int Number = 241; }
abstract class Basis<A> { public abstract int Read<T>(T value) where T : A; }
class Reader : Basis<Record> { public override int Read<T>(T value) { return value.Number; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Reader().Read(new Record()) == 241, "effective-base-calculated-after-substitution");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
