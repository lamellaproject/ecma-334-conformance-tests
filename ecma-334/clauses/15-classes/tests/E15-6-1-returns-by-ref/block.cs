/*
Rules: E15-6-1-returns-by-ref; E15-6-1-grammar-method-declaration-form-2; E15-6-1-grammar-ref-kind-form-1; E15-6-1-grammar-ref-method-modifiers; E15-6-1-grammar-ref-method-body-form-1; E15-6-1-declared-ref-return-type; E15-6-1-ref-block-body-execution
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: return ref Value;
Into: return ref Other;
*/
using System;
class Holder
{
    public int Value = 17, Other = 8, Calls;
    public ref int Cell() { Calls++; return ref Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        ref int alias = ref value.Cell();
        Check(alias == 17, "ref-return-initial-value");
        alias = 23;
        Check(value.Value == 23, "ref-return-aliases-declared-variable");
        Check(value.Other == 8, "ref-return-does-not-alias-other-variable");
        Check(value.Calls == 1, "ref-block-executed-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
