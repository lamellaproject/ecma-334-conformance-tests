/*
Rules: E7-7-2-3-inherited-hiding-warning
Authority: ECMA-334 7th ed 7.7.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Diagnostic: warning
Mutate: public static int Value = 139;
Into: public new static int Value = 139;
*/
using System;
class Root { public static int Value = 137; }
// Compile oracle: the inherited-name-hiding warning is required.
class Branch : Root { public static int Value = 139; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Branch.Value == 139, "hiding-field-has-its-own-storage");
        Check(Root.Value == 137, "hidden-field-retains-base-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
