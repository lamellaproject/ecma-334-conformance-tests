/*
Rules: E7-3-type-indexer-overloads; E7-6-indexer-overloading; E7-6-indexer-signature
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this[string argument]
Into: this[int argument]
*/
using System;
class Holder
{
    public int this[int argument] { get { return 17; } }
    public int this[string argument] { get { return 23; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var value = new Holder();
        Check(value[1] == 17, "integer-indexer-signature");
        Check(value["leaf"] == 23, "string-indexer-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
