/*
Rules: E12-4-5-binary-union
Authority: ECMA-334 7th ed 12.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int result = left + right;
Into: int result = left + (int)right;
*/
using System;
struct Left { public static implicit operator int(Left x) { return 3; } }
struct Right
{
    public static implicit operator int(Right y) { return 5; }
    public static int operator +(Left x, Right y) { return 91; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Left left = new Left(); Right right = new Right(); int result = left + right;
        Check(result == 91, "candidate-from-right-operand");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
