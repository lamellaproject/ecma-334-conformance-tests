/*
Rules: E12-8-7-1-receiver-access-value; E12-8-7-1-receiver-reclassification; E12-8-7-1-instance-lookup
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: owner[Index()].value
Into: owner[1].value
*/
using System;
struct Cell { public int value; }
class Owner
{
    public Cell this[int index]
    {
        get { Program.trace = Program.trace * 10 + 2; return new Cell { value = index + 3 }; }
    }
}
class Program
{
    static int checks, failures;
    public static int trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Index() { trace = trace * 10 + 1; return 0; }
    static void Main()
    {
        Owner owner = new Owner();
        int result = owner[Index()].value;
        Check(result == 3, "indexer-receiver-value-used-for-member-access");
        Check(trace == 12, "index-then-indexer-value-before-field-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
