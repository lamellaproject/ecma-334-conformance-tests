/*
Rules: E15-3-3-runtime-closed-substitution
Authority: ECMA-334 7th ed 15.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new T[2]
Into: new object[2]
*/
using System;
class Stamp { }
class Factory<T> { public object Make() { return new T[2]; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object numbers = new Factory<int>().Make();
        object stamps = new Factory<Stamp>().Make();
        bool numericArray = numbers is int[] && ((int[])numbers).Length == 2 && ((int[])numbers)[0] == 0;
        bool stampArray = stamps is Stamp[] && ((Stamp[])stamps).Length == 2 && ((Stamp[])stamps)[0] == null;
        Check(numericArray, "closed-value-argument-used-in-runtime-array-creation");
        Check(stampArray, "closed-reference-argument-used-in-runtime-array-creation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
