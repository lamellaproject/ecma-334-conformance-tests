/*
Rules: E7-3-type-operator-overloads; E7-6-operator-overloading; E7-6-operator-signature
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator +(Holder left, int right)
Into: operator -(Holder left, int right)
*/
using System;
class Holder
{
    public int Value;
    public static Holder operator +(Holder left, Holder right) { return new Holder { Value = left.Value + right.Value }; }
    public static Holder operator +(Holder left, int right) { return new Holder { Value = left.Value + right }; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder item = new Holder { Value = 2 };
        Check((item + new Holder { Value = 5 }).Value == 7, "two-holder-operator");
        Check((item + 11).Value == 13, "holder-integer-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
