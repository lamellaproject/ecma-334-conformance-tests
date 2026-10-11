/*
Rules: E8-4-5-constraint-boxing
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: value.Value = 31;
Into: value.Value = 32;
*/
using System;
interface IValue { int Read(); }
struct Number : IValue { public int Value; public int Read() { return Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static U Read<T, U>(T value) where T : U { return value; }
    static void Main()
    {
        Number value = new Number(); value.Value = 31;
        Check(Read<Number, IValue>(value).Read() == 31, "nonnullable-boxing-satisfies-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
