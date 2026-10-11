/*
Rules: E12-8-9-3-extension-fallback
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: receiver.Choose("birch")
Into: Extensions.Choose(receiver, "birch")
*/
using System;
class Cell { public int Choose(object value) { return 1; } }
static class Extensions { public static int Choose(this Cell receiver, string value) { return 2; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell receiver = new Cell();
        Check(receiver.Choose("birch") == 1, "applicable-instance-method-prevents-extension-search");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
