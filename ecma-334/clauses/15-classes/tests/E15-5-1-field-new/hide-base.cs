/*
Rules: E15-5-1-field-new; E15-5-1-grammar-field-modifier-form-1
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new int Code = 313;
Into: public override int Code = 313;
*/
using System;
class Basis { public int Code = 271; }
class Holder : Basis { public new int Code = 313; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Code == 313, "new-field-selected");
        Check(((Basis)value).Code == 271, "hidden-base-field-preserved");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
