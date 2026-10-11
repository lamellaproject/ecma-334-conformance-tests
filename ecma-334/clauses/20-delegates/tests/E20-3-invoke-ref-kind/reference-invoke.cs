/*
Rules: E20-3-invoke-ref-kind
Authority: ECMA-334 7th ed 20.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: delegate ref int Edit();
Into: delegate int Edit();
*/
using System;
delegate ref int Edit();
delegate ref readonly int View();
class Program
{
    static int checks, failures;
    static int stored = 107;
    static ref int EditValue() { return ref stored; }
    static ref readonly int ViewValue() { return ref stored; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Edit edit = EditValue;
        View view = ViewValue;
        ref int value = ref edit.Invoke();
        ref readonly int alias = ref view.Invoke();
        Check(value == 107, "invoke-reference-return");
        value = 109;
        Check(stored == 109, "invoke-referenced-variable");
        Check(alias == 109, "invoke-readonly-reference-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
