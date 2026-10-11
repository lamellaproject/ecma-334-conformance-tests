/*
Rules: E15-7-3-ref-block-accessor-execution; E15-7-3-grammar-ref-get-accessor-declaration; E15-7-3-grammar-ref-accessor-body-form-1; E15-7-3-ref-get-method-form; E15-7-3-ref-expression-get-invocation; E15-7-3-ref-property-referent-read; E15-7-3-ref-property-referent-write
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return ref Slot;
Into: return ref Spare;
*/
using System;
class Box
{
    public int Slot = 8, Spare = 24, Calls;
    public ref int Item { get { Calls++; return ref Slot; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        Check(box.Item == 8 && box.Calls == 1, "ref-read-getter");
        box.Item = 37;
        Check(box.Slot == 37 && box.Calls == 2, "ref-write-getter");
        box.Item += 4;
        Check(box.Slot == 41 && box.Calls == 3, "ref-compound-one-getter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
