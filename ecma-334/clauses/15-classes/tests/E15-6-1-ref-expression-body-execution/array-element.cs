/*
Rules: E15-6-1-ref-expression-body-execution; E15-6-1-grammar-ref-method-body-form-2
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public ref int Cell(int[] items) => ref items[Index()];
Into: public ref int Cell(int[] items) => ref items[0];
*/
using System;
class Selector
{
    public int Calls;
    int Index() { Calls++; return 1; }
    public ref int Cell(int[] items) => ref items[Index()];
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Selector value = new Selector();
        int[] items = { 7, 13 };
        ref int alias = ref value.Cell(items);
        Check(alias == 13, "ref-expression-selects-variable");
        alias = 31;
        Check(items[0] == 7 && items[1] == 31, "ref-expression-result-aliases-element");
        Check(value.Calls == 1, "ref-expression-variable-reference-evaluated-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
