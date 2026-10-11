/*
Rules: E7-6-indexer-signature
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: this[string first, int second]
Into: this[int first, string second]
*/
using System;
class Item
{
    public int this[int value] { get { return 53; } }
    public int this[int first, string second] { get { return 59; } }
    public int this[string first, int second] { get { return 61; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item value = new Item();
        Check(value[5] == 53, "indexer-one-parameter");
        Check(value[1, "ash"] == 59, "indexer-parameter-types-int-string");
        Check(value["ash", 1] == 61, "indexer-parameter-types-string-int");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
