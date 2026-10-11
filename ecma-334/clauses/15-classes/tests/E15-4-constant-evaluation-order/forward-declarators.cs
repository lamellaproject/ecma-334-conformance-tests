/*
Rules: E15-4-constant-evaluation-order; E15-4-acyclic-constant-dependency
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public const int First = Third - 9, Second = 101, Third = Second * 3;
Into: public const int First = Third - 9, Second = First, Third = Second * 3;
*/
using System;
class Limits { public const int First = Third - 9, Second = 101, Third = Second * 3; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.First == 294, "forward-constant-first");
        Check(Limits.Second == 101, "forward-constant-origin");
        Check(Limits.Third == 303, "forward-constant-intermediate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
