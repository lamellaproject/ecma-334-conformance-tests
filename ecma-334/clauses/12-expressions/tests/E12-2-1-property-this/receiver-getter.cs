/*
Rules: E12-2-1-property-this; E12-2-1-property-type; E12-2-1-property-instance; E12-2-1-instance-accessor-definition; E12-2-2-property-getter; E12-6-1-category-properties
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Receiver().Score
Into: other.Score
*/
using System;
class Box
{
    public int raw, gets;
    public Box(int value) { raw = value; }
    public int Score { get { gets++; return this.raw; } }
}
class Program
{
    static int checks, failures, receivers;
    static Box chosen = new Box(17), other = new Box(29);
    static Box Receiver() { receivers++; return chosen; }
    static int Choose(int value) { return value; }
    static int Choose(object value) { return -1; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Choose(Receiver().Score);
        Check(result == 17, "property-type-and-this");
        Check(receivers == 1 && chosen.gets == 1 && other.gets == 0, "property-receiver-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
