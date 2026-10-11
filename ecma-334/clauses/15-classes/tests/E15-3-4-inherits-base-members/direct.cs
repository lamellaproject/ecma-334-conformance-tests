/*
Rules: E15-3-4-inherits-base-members; E15-3-4-add-members
Authority: ECMA-334 7th ed 15.3.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: class Child : Parent
Into: class Child
*/
using System;
class Parent
{
    public int Inherited = 277;
    public int Read() { return Inherited + 2; }
}
class Child : Parent { public int Added = 281; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child value = new Child();
        Check(value.Inherited == 277, "direct-base-field-inherited");
        Check(value.Read() == 279, "direct-base-method-inherited");
        Check(value.Added == 281, "derived-declaration-adds-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
