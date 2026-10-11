/*
Rules: E12-24-true-overload-resolution
Authority: ECMA-334 7th ed 12.24
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: if (new Derived())
Into: if ((Base)new Derived())
*/
using System;
class Base
{
    public static bool operator true(Base value) { Program.trace += "B"; return false; }
    public static bool operator false(Base value) { return true; }
}
class Derived : Base
{
    public static bool operator true(Derived value) { Program.trace += "D"; return true; }
    public static bool operator false(Derived value) { return false; }
}
class Program
{
    public static string trace = "";
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int entered = 0;
        if (new Derived()) entered++;
        Check(entered == 1 && trace == "D", "best-derived-true-candidate");
        trace = "";
        Base upcast = new Derived();
        if (upcast) entered++;
        Check(entered == 1 && trace == "B", "lookup-uses-expression-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
