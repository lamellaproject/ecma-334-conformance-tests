/*
Rules: E15-7-4-auto-property-classification; E15-7-4-auto-property-set-optional; E15-7-4-auto-backing-field; E15-7-4-auto-get-read-field; E15-7-4-auto-set-write-field
Authority: ECMA-334 7th ed 15.7.4
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
        Check(a.Item == 0 && b.Item == 0, "initial-auto-storage");
        a.Item = 26; b.Item = 39;
        Check(a.Item == 26 && b.Item == 39, "per-object-auto-storage");
        a.Item = b.Item + 4;
        Check(a.Item == 43 && b.Item == 39, "auto-field-read-and-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
