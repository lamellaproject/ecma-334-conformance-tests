/*
Rules: E6-4-4-grammar-keyword-2; E6-4-4-grammar-keyword-37
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: source as string
Into: source is string
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object source = "bay";
        string shaped = source as string;
        Check(shaped == "bay", "as-type");
        Check(source is string, "is-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
