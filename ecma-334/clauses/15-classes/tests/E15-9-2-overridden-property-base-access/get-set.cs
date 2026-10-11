/*
Rules: E15-9-2-overridden-property-base-access
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: base.Item = value + 3;
Into: base.Item = value + 4;
*/
using System;
class Box { public virtual int Item { get; set; } }
class Derived : Box { public override int Item { get { return base.Item + 5; } set { base.Item = value + 3; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Derived();
        box.Item = 14;
        Check(box.Item == 22, "overridden-property-base-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
