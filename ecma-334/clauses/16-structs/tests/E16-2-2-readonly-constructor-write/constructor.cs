/*
Rules: E16-2-2-readonly-constructor-write; E16-3-member-constructor; E16-4-9-parameterized
Authority: ECMA-334 7th ed 16.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: this.Value = value;
Into: this.Value = 0;
*/
using System;
readonly struct Entry
{
    public readonly int Value;
    public Entry(int value) { this.Value = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = new Entry(73);
        Check(item.Value == 73, "readonly-constructor-write");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
