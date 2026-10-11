/*
Rules: E15-7-4-auto-initializer-direct-field; E15-7-4-auto-initializer-optional
Authority: ECMA-334 7th ed 15.7.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: = Seed();
Into: = 0;
*/
using System;
class Base
{
    public static int Seeds, Sets;
    static int Seed() { Seeds++; return 33; }
    public virtual int Item { get; set; } = Seed();
}
class Derived : Base
{
    public override int Item { get { return base.Item; } set { Sets++; base.Item = value; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived box = new Derived();
        Check(box.Item == 33 && Base.Seeds == 1 && Base.Sets == 0, "initializer-bypasses-setter");
        box.Item = 48;
        Check(box.Item == 48 && Base.Sets == 1, "ordinary-assignment-dispatches-setter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
