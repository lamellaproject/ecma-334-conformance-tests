/*
Rules: E7-7-1-struct-member-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int Value;
Into: public int Renamed;
*/
using System;
struct Item
{
    public int Read() { return Value; }
    public int Value;
    public Item(int value) { Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Item(79).Read() == 79, "struct-member-before-and-after-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
