/*
Rules: E15-7-2-instance-property-association; E15-7-2-instance-property-classification; E15-7-2-instance-property-this
Authority: ECMA-334 7th ed 15.7.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public int Item
Into: public static int Item
*/
using System;
class Box
{
    int stored;
    public Box(int amount) { stored = amount; }
    public Box Owner { get { return this; } }
    public int Item { get { return this.stored; } set { this.stored = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box a = new Box(5), b = new Box(9);
        Check(a.Owner == a && b.Owner == b, "getter-this-identity");
        a.Item = 26;
        Check(a.Item == 26 && b.Item == 9, "setter-specific-instance");
        b.Item = 35;
        Check(a.Item == 26 && b.Item == 35, "independent-instance-property");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
