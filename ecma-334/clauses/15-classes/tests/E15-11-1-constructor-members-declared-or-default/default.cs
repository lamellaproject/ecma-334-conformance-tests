/*
Rules: E15-11-1-constructor-members-declared-or-default
Authority: ECMA-334 7th ed 15.11.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Derived : Basis { }
Into: class Derived : Basis { public Derived(int n) { } }
*/
using System;
class Basis { public int N; public Basis() { N = 13; } }
class Derived : Basis { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Derived().N == 13, "default-constructor-invokes-base");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
