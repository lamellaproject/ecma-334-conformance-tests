/*
Rules: E12-8-9-3-dynamic-ineligible
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic receiver = new Cell();
Into: Cell receiver = new Cell();
*/
using System;
public class Cell { }
static class Extensions { public static int Read(this Cell receiver) { return 5; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new Cell();
        bool rejected = false;
        try { receiver.Read(); }
        catch (Exception) { rejected = true; }
        Check(rejected, "dynamic-receiver-does-not-search-extensions");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
