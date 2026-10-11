/*
Rules: E12-5-1-lookup-criteria; E12-5-1-generic-arity; E12-5-1-nongeneric-arity; E12-5-1-match-arity; E12-5-1-method-group
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: receiver.Pick<int>()
Into: receiver.Pick<int, int>()
*/
using System;
class Base { public int Accessible<T>(object value) { return 17; } }
class Derived : Base
{
    public int Pick() { return 11; }
    public int Pick<T>() { return 13; }
    public int Pick<T, U>() { return 19; }
    private int Accessible<T>(int value) { return 23; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived(); int result = receiver.Pick<int>();
        Check(receiver.Pick() == 11, "zero-arity-member");
        Check(result == 13, "one-arity-member");
        Check(receiver.Pick<int, string>() == 19, "two-arity-member");
        Check(receiver.Accessible<int>(3) == 17, "inaccessible-member-removed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
