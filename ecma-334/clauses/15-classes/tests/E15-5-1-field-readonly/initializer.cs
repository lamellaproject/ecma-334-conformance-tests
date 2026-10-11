/*
Rules: E15-5-1-field-readonly; E15-5-1-grammar-field-modifier-form-7
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public readonly int Code = 937;
Into: public readonly int Other = 937;
*/
using System;
class Holder { public readonly int Code = 937; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Code == 937, "readonly-field-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
