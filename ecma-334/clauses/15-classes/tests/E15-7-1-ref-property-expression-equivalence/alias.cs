/*
Rules: E15-7-1-ref-property-expression-equivalence; E15-7-1-grammar-ref-property-body-form-2
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Expr => ref Slot;
Into: Expr => ref Other;
*/
using System;
class Box
{
    public int Slot = 9, Other = 20;
    public ref int Expr => ref Slot;
    public ref int Block { get { return ref Slot; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        ref int a = ref box.Expr;
        ref int b = ref box.Block;
        Check(a == 9 && b == 9, "equivalent-initial-read");
        a = 34;
        Check(b == 34 && box.Slot == 34, "expression-alias");
        b = 42;
        Check(a == 42, "block-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
