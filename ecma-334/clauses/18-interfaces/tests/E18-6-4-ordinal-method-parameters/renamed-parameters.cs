/*
Rules: E18-6-4-ordinal-method-parameters
Authority: ECMA-334 7th ed 18.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public Y Read<X, Y>(Y value) where X : IValue where Y : X
Into: public Y Read<X, Y>(Y value) where X : IValue where Y : IValue
*/
using System;
interface IValue { int Value(); }
interface IRead { B Read<A, B>(B value) where A : IValue where B : A; }
class Item : IValue { public int Value() { return 263; } }
class Reader : IRead
{
    public Y Read<X, Y>(Y value) where X : IValue where Y : X { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead reader = new Reader();
        Item item = new Item();
        Check(reader.Read<IValue, Item>(item) == item, "equivalence-by-ordinal-not-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
