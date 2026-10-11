/*
Rules: E12-6-4-3-specific-constructed
Authority: ECMA-334 7th ed 12.6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Choice<int>().Pick(new Box<int>())
Into: new Choice<long>().Pick(new Box<long>())
*/
using System;
class Box<T> { }
class Choice<T>
{
    public int Pick(Box<T> value) { return 1; }
    public int Pick(Box<int> value) { return 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Choice<int>().Pick(new Box<int>()) == 2, "generic-argument-specificity-recurses-before-instantiation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
