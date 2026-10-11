/*
Rules: E12-8-11-1-dynamic-argument; E12-8-11-1-dynamic-value; E12-8-11-1-dynamic-runtime-types; E12-8-11-1-dynamic-limited-check
Authority: ECMA-334 7th ed 12.8.11.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver[argument]
Into: receiver[(object)argument]
*/
using System;
public class Cell
{
    public string this[string key] { get { return "string"; } }
    public string this[object key] { get { return "object"; } }
}
class Program
{
    static int checks, failures;
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell receiver = new Cell(); dynamic argument = "oak";
        var result = receiver[argument];
        Check(result == "string", "runtime-index-type-selects-indexer");
        Check(Kind(result) == 1, "dynamic-indexer-result-classification");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
