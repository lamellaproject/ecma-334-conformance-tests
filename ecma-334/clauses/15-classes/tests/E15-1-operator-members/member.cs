/*
Rules: E15-1-operator-members
Authority: ECMA-334 7th ed 15.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return left.Value + right.Value;
Into: return left.Value - right.Value;
*/
using System;
class Meter
{
    public int Value;
    public static int operator +(Meter left, Meter right) { return left.Value + right.Value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Meter left = new Meter();
        Meter right = new Meter();
        left.Value = 8;
        right.Value = 5;
        Check(left + right == 13, "class-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
