/*
Rules: E15-7-1-property-initializer-field-value; E15-7-1-grammar-property-initializer
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: = Seed();
Into: = 0;
*/
using System;
class Box
{
    public static int Calls;
    static int Seed() { Calls++; return 32; }
    public int Item { get; set; } = Seed();
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        Check(box.Item == 32 && Box.Calls == 1, "initialized-field");
        box.Item = 49;
        Check(box.Item == 49 && Box.Calls == 1, "initializer-not-getter");
        Check(new Box().Item == 32 && Box.Calls == 2, "per-instance-initialization");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
