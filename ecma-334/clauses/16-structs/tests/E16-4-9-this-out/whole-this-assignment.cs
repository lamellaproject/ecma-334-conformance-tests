/*
Rules: E16-4-9-this-out
Authority: ECMA-334 7th ed 16.4.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this = default(Entry);
Into: 
*/
using System;
struct Entry
{
    public int Value;
    public bool Flag;
    public Entry(int value) { this = default(Entry); Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = new Entry(167);
        Check(item.Value == 167, "constructor-this-assignment-value");
        Check(!item.Flag, "constructor-this-assignment-other-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
