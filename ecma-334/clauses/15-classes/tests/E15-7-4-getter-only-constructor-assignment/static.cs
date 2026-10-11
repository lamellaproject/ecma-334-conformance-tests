/*
Rules: E15-7-4-getter-only-constructor-assignment; E15-7-4-getter-only-assignment-direct-field
Authority: ECMA-334 7th ed 15.7.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Item = 31;
Into: Item = 0;
*/
using System;
class Box { public static int Item { get; } static Box() { Item = 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { Check(Box.Item == 31, "static-constructor-readonly-storage"); if (failures == 0) Console.WriteLine("OK " + checks); }
}
