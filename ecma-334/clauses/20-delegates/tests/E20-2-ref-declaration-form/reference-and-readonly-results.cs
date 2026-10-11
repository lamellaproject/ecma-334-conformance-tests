/*
Rules: E20-2-ref-declaration-form; E20-2-returns-by-ref; E20-2-ref-variable-type
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: delegate ref int Edit();
Into: delegate int Edit();
*/
using System;
class MarkAttribute : Attribute { }
[Mark] delegate ref int Edit();
delegate ref readonly int View();
class Program
{
    static int checks, failures;
    static int stored = 17;
    static ref int EditValue() { return ref stored; }
    static ref readonly int ViewValue() { return ref stored; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Edit edit = EditValue;
        View view = ViewValue;
        ref int value = ref edit();
        ref readonly int snapshot = ref view();
        Check(value == 17, "reference-result-initial");
        value = 19;
        Check(stored == 19, "write-to-returned-variable");
        Check(snapshot == 19, "readonly-reference-observes-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
