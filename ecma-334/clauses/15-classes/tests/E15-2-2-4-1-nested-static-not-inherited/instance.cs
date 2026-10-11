/*
Rules: E15-2-2-4-1-nested-static-not-inherited
Authority: ECMA-334 7th ed 15.2.2.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Item
Into: public static class Item
*/
using System;
static class Crate { public class Item { public int Reading = 149; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Crate.Item().Reading == 149, "nested-class-is-instance-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
