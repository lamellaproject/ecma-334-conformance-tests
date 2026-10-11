/*
Rules: E6-4-5-7-null-value; E6-4-5-7-grammar-null-literal-1; E6-4-5-7-null-reference-conversion; E6-4-5-7-null-nullable-conversion; E6-4-5-1-grammar-literal-6; E6-3-1-grammar-null-1
Authority: ECMA-334 7th ed 6.4.5.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: string text = null;
Into: string text = "";
*/
using System;
class Parcel { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text = null;
        Parcel parcel = null;
        int? number = null;
        Check(text == null, "string-reference");
        Check(parcel == null, "class-reference");
        Check(!number.HasValue, "nullable-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
