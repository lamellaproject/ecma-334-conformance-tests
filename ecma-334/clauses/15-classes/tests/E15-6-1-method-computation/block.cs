/*
Rules: E15-6-1-method-computation; E15-6-1-grammar-method-declaration-form-1; E15-6-1-grammar-method-header-form-1; E15-6-1-grammar-method-modifier-form-1; E15-6-1-grammar-return-type-form-1; E15-6-1-grammar-ref-return-type; E15-6-1-grammar-member-name-form-1; E15-6-1-grammar-method-body-form-1; E15-6-1-returns-by-value; E15-6-1-declared-return-type; E15-6-1-member-name-method-name; E15-6-1-formal-parameters; E15-6-1-block-body-execution
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return left + right;
Into: return left - right;
*/
using System;
class Calculator
{
    public int Calls;
    public int Combine(int left, int right) { Calls++; return left + right; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Calculator value = new Calculator();
        Check(value.Combine(7, 11) == 18, "method-returns-declared-result");
        Check(value.Calls == 1, "method-block-performs-action");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
