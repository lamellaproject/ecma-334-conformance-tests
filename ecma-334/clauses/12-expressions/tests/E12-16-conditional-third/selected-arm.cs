/*
Rules: E12-16-conditional-third; E12-16-implicit-throw-conversion
Authority: ECMA-334 7th ed 12.16
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Choose(false) ? "kept" : throw saved
Into: Choose(true) ? "kept" : throw saved
*/
using System;
class Program
{
    static bool Choose(bool b) { return b; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Exception saved = new Exception(); var a = Choose(true) ? "kept" : throw saved;
        Check(a == "kept", "third-arm-throw-converts-to-string");
        try { string b = Choose(false) ? "kept" : throw saved; Check(false, "third-arm-must-throw"); }
        catch (Exception e) { Check(object.ReferenceEquals(e, saved), "third-arm-throws-same-instance"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
