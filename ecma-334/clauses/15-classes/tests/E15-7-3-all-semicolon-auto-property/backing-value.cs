/*
Rules: E15-7-3-all-semicolon-auto-property; E15-7-3-grammar-accessor-body-form-3
Authority: ECMA-334 7th ed 15.7.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int Item { get; set; }
Into: int Item { get; }
*/
using System;
class Box { public int Item { get; set; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box a = new Box(), b = new Box();
        Check(a.Item == 0 && b.Item == 0, "auto-default-value");
        a.Item = 28;
        Check(a.Item == 28 && b.Item == 0, "auto-distinct-storage");
        a.Item = 39;
        Check(a.Item == 39, "auto-repeated-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
