/*
Rules: E15-4-grammar-constant-modifier-form-5; E15-4-constant-accessibility
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private const int Code = 701;
Into: private const int Other = 701;
*/
using System;
class Limits
{
    private const int Code = 701;
    public static int Read() { return Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Read() == 701, "private-constant-in-own-class");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
