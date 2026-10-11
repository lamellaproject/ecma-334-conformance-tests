/*
Rules: E15-3-1-constant-category; E15-3-1-grammar-class-member-declaration-form-1
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Bound = 83;
Into: public static int Bound = 83;
*/
using System;
class Limits { public const int Bound = 83; }
class Program
{
    const int Recorded = Limits.Bound + 2;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Recorded == 85, "class-constant-used-in-constant-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
