/*
Rules: E15-6-2-1-method-declaration-space; E15-6-2-1-body-nested-in-space
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int Right(int value) { int result = value - 2; return result; }
Into: static int Right(int result) { int result = 3; return result; }
*/
using System;
class Program
{
    static int Left(int value) { int result = value + 7; return result; }
    static int Right(int value) { int result = value - 2; return result; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Left(5) == 12, "first-method-parameter-and-body-scope");
        Check(Right(5) == 3, "other-method-reuses-names-in-separate-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
