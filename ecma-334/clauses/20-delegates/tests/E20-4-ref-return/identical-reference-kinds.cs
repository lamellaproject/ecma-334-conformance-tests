/*
Rules: E20-4-ref-return
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: static ref readonly int ViewValue() { return ref stored; }
Into: static int ViewValue() { return stored; }
*/
using System;
delegate ref int Edit();
delegate ref readonly int View();
class Program
{
    static int checks, failures;
    static int stored = 97;
    static ref int EditValue() { return ref stored; }
    static ref readonly int ViewValue() { return ref stored; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Edit method = EditValue;
        Edit wrapped = new Edit(method);
        View readonlyMethod = ViewValue;
        View readonlyWrapped = new View(readonlyMethod);
        ref int edit = ref wrapped();
        Check(edit == 97, "identity-reference-result");
        edit = 101;
        Check(method() == 101, "compatible-delegate-reference-alias");
        Check(readonlyMethod() == 101, "identity-readonly-result");
        Check(readonlyWrapped() == 101, "compatible-readonly-delegate-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
