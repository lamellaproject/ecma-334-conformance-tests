/*
Rules: E15-7-4-getter-only-constructor-assignment; E15-7-4-getter-only-assignment-direct-field; E15-7-4-getter-only-field-readonly
Authority: ECMA-334 7th ed 15.7.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this.Item = amount;
Into: this.Item = 0;
*/
using System;
class Box { public int Item { get; } public Box(int amount) { this.Item = amount; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box a = new Box(28), b = new Box(47);
        Check(a.Item == 28, "constructor-writes-readonly-storage");
        Check(b.Item == 47 && a.Item == 28, "constructor-distinct-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
