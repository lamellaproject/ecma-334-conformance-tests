/*
Rules: E7-3-class-operator-declaration; E7-4-5-class-operator-declaration; E7-4-1-member-inheritance; E7-4-5-class-members; E7-7-1-operator-parameter-scope
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: operator +(Holder left, Holder right)
Into: operator -(Holder left, Holder right)
*/
using System;
class Holder
{
    public int Value;
    public static Holder operator +(Holder left, Holder right)
    { return new Holder { Value = left.Value + right.Value }; }
}
class Derived : Holder { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder sum = new Derived { Value = 2 } + new Derived { Value = 5 };
        Check(sum.Value == 7, "class-operator-declared");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
