/*
Rules: E15-6-1-expression-body-execution; E15-6-1-grammar-method-body-form-3
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Scale(int value) => value * 3;
Into: public int Scale(int value) => value + 3;
*/
using System;
class Calculator { public int Scale(int value) => value * 3; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Calculator().Scale(5) == 15, "expression-body-evaluates-on-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
