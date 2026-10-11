/*
Rules: E12-4-6-type-parameter-base
Authority: ECMA-334 7th ed 12.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left + right
Into: left - right
*/
using System;
class Base { public static int operator +(Base x, Base y) { return 73; } }
class Derived : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Sum<T>(T left, T right) where T : Base { return left + right; }
    static void Main()
    {
        Check(Sum<Derived>(new Derived(), new Derived()) == 73, "effective-base-operator-candidates");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
