/*
Rules: E15-6-2-1-default-constant-expression; E15-6-2-1-grammar-default-argument; E15-6-2-1-optional-parameter-classification; E15-6-2-1-required-parameter-classification
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int second = Seed + 4
Into: int second = Seed + 6
*/
using System;
class Program
{
    const int Seed = 3;
    static int Combine(int first, int second = Seed + 4) { return first * 10 + second; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Combine(2) == 27, "omitted-optional-argument-uses-constant-expression");
        Check(Combine(2, 9) == 29, "supplied-optional-argument-replaces-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
