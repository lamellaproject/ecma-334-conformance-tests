/*
Rules: E15-3-1-type-category; E15-3-1-grammar-class-member-declaration-form-11
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Entry { public int Number = 167; }
Into: public class Other { public int Number = 167; }
*/
using System;
class Catalog { public class Entry { public int Number = 167; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Catalog.Entry value = new Catalog.Entry();
        Check(value.Number == 167, "nested-type-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
