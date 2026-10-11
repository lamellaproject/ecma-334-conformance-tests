/*
Rules: E12-8-16-2-class-default-fields
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Number;
Into: public int Number = 9;
*/
using System;
class Item
{
    public int Number;
    public object Link;
    public bool Flag;
    public double Real;
    public bool Defaults;
    public Item() { Defaults = Number == 0 && Link == null && !Flag && Real == 0.0 && !Defaults; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item value = new Item();
        Check(value.Defaults, "class-default-fields-observed-in-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
