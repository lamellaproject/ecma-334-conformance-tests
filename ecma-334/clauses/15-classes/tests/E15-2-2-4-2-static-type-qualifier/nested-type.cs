/*
Rules: E15-2-2-4-2-static-type-qualifier
Authority: ECMA-334 7th ed 15.2.2.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Crate.Item item = new Crate.Item();
Into: Crate item = new Crate.Item();
*/
using System;
static class Crate { public class Item { public int Reading = 157; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Crate.Item item = new Crate.Item();
        Check(item.Reading == 157, "static-class-qualifies-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
