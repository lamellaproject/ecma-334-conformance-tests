/*
Rules: E7-8-1-static-class-prefix-context
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Item { public int Value = 139; }
Into: public class Other { public int Value = 139; }
*/
using System;
static class Tools { public class Item { public int Value = 139; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Tools.Item().Value == 139, "static-class-as-qualified-type-prefix");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
