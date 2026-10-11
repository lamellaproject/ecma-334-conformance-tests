/*
Rules: E15-6-1-override-inherits-constraints
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public override T Create<T>() { return new T(); }
Into: public override T Create<T>() { return default(T); }
*/
using System;
class Item { public int Value = 89; }
abstract class Parent { public abstract T Create<T>() where T : Item, new(); }
class Factory : Parent { public override T Create<T>() { return new T(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Parent factory = new Factory();
        Item value = factory.Create<Item>();
        Check(value != null && value.Value == 89, "override-body-uses-inherited-base-and-new-constraints");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
