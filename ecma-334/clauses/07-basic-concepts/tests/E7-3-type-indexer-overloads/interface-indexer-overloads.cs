/*
Rules: E7-3-type-indexer-overloads; E7-6-indexer-overloading
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int this[string argument] { get; }
Into: int this[int argument] { get; }
*/
using System;
interface Contract { int this[int argument] { get; } int this[string argument] { get; } }
class Holder : Contract
{
    public int this[int argument] { get { return 37; } }
    public int this[string argument] { get { return 41; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Contract value = new Holder();
        Check(value[1] == 37, "interface-integer-indexer");
        Check(value["leaf"] == 41, "interface-string-indexer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
