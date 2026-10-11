/*
Rules: E15-6-1-grammar-ref-method-body-form-3; E15-6-1-grammar-ref-method-modifier-form-10
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public abstract ref int Cell();
Into: public abstract int Cell();
*/
using System;
abstract class Parent { public abstract ref int Cell(); }
class Holder : Parent
{
    public int Value = 13;
    public override ref int Cell() { return ref Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Parent parent = value;
        ref int alias = ref parent.Cell();
        Check(alias == 13, "abstract-ref-semicolon-declaration-binds-override");
        alias = 47;
        Check(value.Value == 47, "abstract-ref-method-return-is-an-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
