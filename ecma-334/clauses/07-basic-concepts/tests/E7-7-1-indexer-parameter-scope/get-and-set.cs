/*
Rules: E7-7-1-indexer-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: this[int index]
Into: this[int renamed]
*/
using System;
class Item
{
    public int Last;
    public int this[int index]
    {
        get { if (index == 0) return 107; return index + 109; }
        set { Last = index + value; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Item value = new Item();
        Check(value[0] == 107, "indexer-parameter-in-nested-get-statement");
        Check(value[4] == 113, "indexer-parameter-in-final-get-return");
        value[5] = 127;
        Check(value.Last == 132, "indexer-parameter-in-set-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
