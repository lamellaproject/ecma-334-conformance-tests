/*
Rules: E12-8-14-member-form; E12-8-14-hidden-members; E12-8-14-member-binding
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return base.Field;
Into: return this.Field;
*/
using System;
class Root
{
    public int Field;
    public T Echo<T>(T value) { return value; }
}
class Leaf : Root
{
    public new int Field = 40;
    public Leaf() { base.Field = 17; }
    public new int Echo<T>(T value) { return 90; }
    public int InheritedField { get { return base.Field; } }
    public int InheritedMethod() { return base.Echo<int>(23); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf leaf = new Leaf();
        Check(leaf.InheritedField == 17, "base-accessor-reaches-hidden-field");
        Check(leaf.InheritedMethod() == 23, "base-generic-method-binds-to-base-declaration");
        Check(leaf.Field == 40, "base-constructor-write-does-not-touch-derived-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
