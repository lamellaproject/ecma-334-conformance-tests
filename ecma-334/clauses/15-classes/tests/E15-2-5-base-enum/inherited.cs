/*
Rules: E15-2-5-base-enum
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Reader : Basis<Reading>
Into: class Reader : Basis<ValueType>
*/
using System;
enum Reading { Ready }
abstract class Basis<A> { public abstract int Read<T>(T value) where T : A; }
class Reader : Basis<Reading>
{
    static int Pick(object value) { return 1; }
    static int Pick(ValueType value) { return 2; }
    static int Pick(Enum value) { return 3; }
    public override int Read<T>(T value) { return Pick(value); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Reader().Read(Reading.Ready) == 3, "substituted-enum-constraint-has-enum-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
