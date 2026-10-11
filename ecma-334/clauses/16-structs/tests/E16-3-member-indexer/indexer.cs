/*
Rules: E16-3-member-indexer
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: return stored + offset;
Into: return stored;
*/
using System;
struct Entry
{
    int stored;
    public int this[int offset] { get { return stored + offset; } set { stored = value - offset; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = new Entry(); item[3] = 97;
        Check(item[3] == 97, "indexer-set-get");
        Check(item[0] == 94, "indexer-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
