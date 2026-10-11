/*
Rules: E12-21-2-implicit-variable-inference; E12-21-2-implicit-assignment-type; E12-21-1-deconstruction-declaration; E12-22-declaration-form
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (var number, var text) = (17, "note");
Into: (var number, var text) = (18, "note");
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool IsInt(int value) { return true; }
    static bool IsInt(object value) { return false; }
    static bool IsString(string value) { return true; }
    static bool IsString(object value) { return false; }
    static bool IsShort(short value) { return true; }
    static bool IsShort(int value) { return false; }
    static void Main()
    {
        (var number, var text) = (17, "note");
        Check(IsInt(number) && number == 17 && IsString(text) && text == "note", "recursive-inferred-types");
        (var kept, _) = ((short)9, "discarded");
        Check(kept == 9 && IsShort(kept), "inferred-declaration-with-simple-discard");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
