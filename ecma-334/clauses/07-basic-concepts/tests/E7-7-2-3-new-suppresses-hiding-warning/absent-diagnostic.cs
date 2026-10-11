/*
Rules: E7-7-2-3-new-suppresses-hiding-warning
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: public new static int Value = 151;
Into: public static int Value = 151;
*/
using System;
class Root { public static int Value = 149; }
// Compile oracle: new suppresses the inherited-name-hiding warning.
class Branch : Root { public new static int Value = 151; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Branch.Value == 151, "new-field-has-its-own-storage");
        Check(Root.Value == 149, "hidden-field-retains-base-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
