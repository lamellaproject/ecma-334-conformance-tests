/*
Rules: E12-23-null-reference; E12-23-reference-type-permission; E12-23-default-value
Authority: ECMA-334 7th ed 12.23
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: (string)(object)null
Into: (string)(object)"text"
*/
using System;
class Base { }
class Derived : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const string text = "ca" + "se";
        const object empty = default(object);
        const Base upcast = (Base)(Derived)null;
        const Derived downcast = (Derived)(Base)null;
        const string nullText = (string)(object)null;
        Check(text == "case", "nonnull-string-constant");
        Check(empty == null, "default-reference-constant");
        Check(upcast == null && downcast == null, "implicit-and-explicit-null-reference-conversions");
        Check(nullText == null, "null-object-to-string-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
