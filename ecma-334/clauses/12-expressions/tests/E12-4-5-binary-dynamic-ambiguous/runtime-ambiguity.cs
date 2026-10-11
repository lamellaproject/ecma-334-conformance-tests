/*
Rules: E12-4-5-binary-dynamic-ambiguous
Authority: ECMA-334 7th ed 12.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left + right
Into: left + (int)right
*/
using System;
public struct Left
{
    public static implicit operator int(Left x) { return 3; }
    public static int operator +(Left x, int y) { return 1; }
}
public struct Right
{
    public static implicit operator int(Right y) { return 5; }
    public static int operator +(int x, Right y) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic left = new Left(), right = new Right(); bool caught = false;
        try { int result = left + right; }
        catch (Exception) { caught = true; }
        Check(caught, "dynamic-binary-binding-error");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
