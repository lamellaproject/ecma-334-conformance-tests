/*
Rules: E12-6-2-3-array-reference-mismatch; E12-6-2-3-array-reference-check
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Root[] wrong = new Leaf[2];
Into: Root[] wrong = new Root[2];
*/
using System;
class Root { }
class Leaf : Root { }
class Program
{
    static int checks, failures, calls;
    static void Reference(ref Root value) { calls++; value = new Root(); }
    static void Output(out Root value) { calls++; value = new Root(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Root[] exact = new Root[2]; Reference(ref exact[1]); Output(out exact[0]);
        Check(calls == 2 && exact[0] != null && exact[1] != null, "identical-array-element-type");
        Root[] wrong = new Leaf[2]; bool reference = false, output = false;
        try { Reference(ref wrong[1]); }
        catch (ArrayTypeMismatchException) { reference = true; }
        catch (Exception) { }
        Check(reference && calls == 2, "covariant-reference-check-before-body");
        try { Output(out wrong[0]); }
        catch (ArrayTypeMismatchException) { output = true; }
        catch (Exception) { }
        Check(output && calls == 2, "covariant-output-check-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
