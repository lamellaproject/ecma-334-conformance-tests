/*
Rules: E7-4-1-static-constructor-not-inherited
Authority: ECMA-334 7th ed 7.4.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static Base()
Into: static Renamed()
*/
using System;
class Trace { public static int Initializations; }
class Base
{
    static Base() { Trace.Initializations++; }
    public static int Read() { return 17; }
}
class Derived : Base { public static int Own() { return 23; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first = Derived.Own();
        Check(first == 23 && Trace.Initializations == 0, "derived-own-static-call-did-not-inherit-base-initializer");
        int second = Base.Read();
        Check(second == 17 && Trace.Initializations == 1, "base-initializes-for-its-own-call");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
