/*
Rules: E15-7-1-ref-property-variable-reference; E15-7-1-grammar-property-declaration-form-2; E15-7-1-grammar-ref-property-body-form-1; E15-7-1-ref-property-statement-get
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: return ref slot;
Into: return ref spare;
*/
using System;
class Box
{
    int slot = 7, spare = 19;
    public int Reads;
    public ref int Item { get { Reads++; return ref slot; } }
    public int Stored { get { return slot; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        ref int alias = ref box.Item;
        Check(alias == 7 && box.Reads == 1, "getter-reference");
        alias = 23;
        Check(box.Stored == 23, "alias-writes-storage");
        box.Item = 31;
        Check(alias == 31 && box.Reads == 2, "property-assignment-through-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
