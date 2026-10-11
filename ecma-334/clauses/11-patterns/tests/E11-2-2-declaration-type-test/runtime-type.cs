/*
Rules: E11-2-2-declaration-type-test; E11-2-2-declaration-null-never-matches
Authority: ECMA-334 7th ed 11.2.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: source is Parent found
Into: source is Child found
*/
using System;
class Parent { }
class Child : Parent { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Matches(object source) { return source is Parent found; }
    static void Main()
    {
        Check(Matches(new Parent()), "exact-type");
        Check(Matches(new Child()), "derived-type");
        Check(!Matches(new object()), "unrelated-type");
        Check(!Matches(null), "null-never");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
