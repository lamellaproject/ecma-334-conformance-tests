/*
Rules: E15-4-constant-new; E15-4-grammar-constant-modifier-form-1; E15-4-constant-accessibility
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public new const int Mark = 409;
Into: public override const int Mark = 409;
*/
using System;
class Basis { public const int Mark = 307; }
class Leaf : Basis { public new const int Mark = 409; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Basis.Mark == 307, "base-constant-preserved");
        Check(Leaf.Mark == 409, "new-constant-selected");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
