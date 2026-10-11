/*
Rules: E15-7-3-ref-expression-accessor-evaluation; E15-7-3-grammar-ref-accessor-body-form-2
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: get => ref Slots[Pick()];
Into: get => ref Slots[0];
*/
using System;
class Box
{
    public int[] Slots = { 6, 13 };
    public int Calls;
    int Pick() { return Calls++ % 2; }
    public ref int Item { get => ref Slots[Pick()]; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        ref int first = ref box.Item;
        Check(first == 6 && box.Calls == 1, "first-reference-evaluation");
        box.Item = 31;
        Check(box.Slots[1] == 31 && first == 6 && box.Calls == 2, "assignment-reference-evaluation");
        ref int third = ref box.Item;
        third = 42;
        Check(first == 42 && box.Calls == 3, "fresh-reference-per-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
