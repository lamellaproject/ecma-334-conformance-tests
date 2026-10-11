/*
Rules: E18-6-2-inherited-constraints
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int IRead.Read<T>(T value)
Into: public int Read<T>(T value)
*/
using System;
interface IValue { int Value(); }
interface IRead { int Read<T>(T value) where T : IValue; }
class Item : IValue { public int Value() { return 197; } }
class Reader : IRead { int IRead.Read<T>(T value) { return value.Value(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead reader = new Reader();
        Check(reader.Read(new Item()) == 197, "bound-inherited-by-explicit-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
