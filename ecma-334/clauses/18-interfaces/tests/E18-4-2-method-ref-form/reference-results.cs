/*
Rules: E18-4-2-method-ref-form
Authority: ECMA-334 7th ed 18.4.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public ref int Edit() { return ref cell; }
Into: public ref int Edit() { return ref other; }
*/
using System;
interface ICell { ref int Edit(); ref readonly int View(); }
class Cell : ICell
{
    int cell = 67, other = -1;
    public ref int Edit() { return ref cell; }
    public ref readonly int View() { return ref cell; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ICell cell = new Cell();
        ref int edit = ref cell.Edit();
        ref readonly int view = ref cell.View();
        Check(edit == 67, "reference-result");
        edit = 71;
        Check(view == 71, "readonly-reference-alias");
        Check(cell.Edit() == 71, "write-through-interface-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
