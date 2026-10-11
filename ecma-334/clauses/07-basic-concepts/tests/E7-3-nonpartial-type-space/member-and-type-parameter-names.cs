/*
Rules: E7-3-nonpartial-type-space; E7-3-type-member-names
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Second<T>
Into: class Second<U>
*/
using System;
class First<T> { public T Echo(T value) { return value; } }
class Second<T> { public T Echo(T value) { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new First<int>().Echo(23) == 23, "first-type-space");
        Check(new Second<string>().Echo("branch") == "branch", "second-type-space");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
