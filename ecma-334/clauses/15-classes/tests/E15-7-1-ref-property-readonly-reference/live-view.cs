/*
Rules: E15-7-1-ref-property-readonly-reference
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: View => ref Slot;
Into: View => ref Spare;
*/
using System;
class Box { public int Slot = 13, Spare = 13; public ref readonly int View => ref Slot; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        ref readonly int view = ref box.View;
        Check(view == 13, "readonly-initial-value");
        box.Slot = 29;
        Check(view == 29 && box.View == 29, "readonly-live-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
