/*
Rules: E23-6-3-member-indirection-equivalence
Authority: ECMA-334 7th ed 23.6.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Observe(&value)->Value = 29;
Into: Observe(&other)->Value = 29;
*/
using System;
struct Item { public int Value; }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int calls;
    static Item* Observe(Item* value) { calls++; return value; }
    static void Main()
    {
        Item value = new Item(), other = new Item();
        value.Value = 11;
        int read = Observe(&value)->Value;
        Check(read == 11, "arrow-read");
        Check(calls == 1, "arrow-read-receiver-once");
        Observe(&value)->Value = 29;
        Check(value.Value == 29 && other.Value == 0, "arrow-write");
        Check(calls == 2, "arrow-write-receiver-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
