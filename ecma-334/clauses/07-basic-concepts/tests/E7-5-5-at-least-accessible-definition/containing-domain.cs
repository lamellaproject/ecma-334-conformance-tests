/*
Rules: E7-5-5-at-least-accessible-definition; E7-5-1-accessibility-composition
Authority: ECMA-334 7th ed 7.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: internal class Holder
Into: public class Holder
*/
using System;
internal class Item { public int Value = 137; }
internal class Holder { public Item Value = new Item(); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Value.Value == 137, "internal-type-covers-public-member-of-internal-container");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
