/*
Rules: E7-3-class-static-constructor-declaration; E7-4-5-class-static-constructor-declaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static Holder()
Into: static Renamed()
*/
using System;
class Holder
{
    public static int Value;
    static Holder() { Value = 43; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Holder.Value == 43, "static-constructor-declared");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
