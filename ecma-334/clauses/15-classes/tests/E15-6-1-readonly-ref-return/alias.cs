/*
Rules: E15-6-1-readonly-ref-return; E15-6-1-grammar-ref-kind-form-2
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return ref Value;
Into: return ref Other;
*/
using System;
class Holder
{
    public int Value = 17, Other = 8;
    public ref readonly int Cell() { return ref Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        ref readonly int alias = ref value.Cell();
        Check(alias == 17, "readonly-reference-reads-variable");
        value.Value = 29;
        Check(alias == 29, "readonly-reference-remains-an-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
