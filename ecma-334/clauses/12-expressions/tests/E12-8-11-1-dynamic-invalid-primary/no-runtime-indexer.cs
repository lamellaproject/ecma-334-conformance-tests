/*
Rules: E12-8-11-1-dynamic-invalid-primary; E12-8-11-3-dynamic-indexer-primary
Authority: ECMA-334 7th ed 12.8.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic receiver = Number.Three;
Into: dynamic receiver = new Cell();
*/
using System;
public enum Number { Three = 3 }
public class Cell { public int this[int index] { get { return 5; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = Number.Three;
        bool rejected = false;
        try { object result = receiver[0]; }
        catch (Exception) { rejected = true; }
        Check(rejected, "enum-receiver-cannot-provide-indexer-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
