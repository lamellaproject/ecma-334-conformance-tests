/*
Rules: E12-8-16-2-type-parameter-runtime-type; E12-8-16-2-type-parameter-constructor
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: return new T();
Into: return default(T);
*/
using System;
class Item
{
    public static int Calls;
    public int Number;
    public Item() { Calls++; Number = 29; }
}
struct State { public int Number; public object Link; }
class Program
{
    static T Create<T>() where T : new() { return new T(); }
    static T CreateValue<T>() where T : struct { T result = new T(); return result; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item item = Create<Item>();
        State state = CreateValue<State>();
        Check(item is Item, "bound-class-runtime-type");
        Check(item != null && item.Number == 29 && Item.Calls == 1, "bound-class-default-constructor");
        Check(state.Number == 0 && state.Link == null, "bound-struct-default-value");
        Check(Create<int>() == 0, "constructor-constraint-value-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
