/*
Rules: E7-3-constructor-initializer-space; E7-3-constructor-body-space
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out int initialized
Into: out int renamed
*/
using System;
class Base
{
    public int Value;
    public Base(int value) { Value = value; }
}
class Derived : Base
{
    public int Other;
    public Derived() : base(Produce(out int initialized)) { Other = initialized; }
    static int Produce(out int value) { value = 31; return 37; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = new Derived();
        Check(value.Value == 37 && value.Other == 31, "initializer-local-visible-in-nested-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
