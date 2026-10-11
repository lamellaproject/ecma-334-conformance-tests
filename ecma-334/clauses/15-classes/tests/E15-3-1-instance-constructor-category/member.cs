/*
Rules: E15-3-1-instance-constructor-category; E15-3-1-grammar-class-member-declaration-form-8
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public Stamp(int number) { Number = number; Calls++; }
Into: public Stamp(int number) { }
*/
using System;
class Stamp
{
    public int Number;
    public static int Calls;
    public Stamp(int number) { Number = number; Calls++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Stamp value = new Stamp(151);
        Check(value.Number == 151, "constructor-initializes-instance");
        Check(Stamp.Calls == 1, "constructor-action-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
