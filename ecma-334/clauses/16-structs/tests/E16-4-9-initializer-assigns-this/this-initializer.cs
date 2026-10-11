/*
Rules: E16-4-9-initializer-assigns-this; E16-4-9-initialized-body
Authority: ECMA-334 7th ed 16.4.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: : this()
Into: 
*/
using System;
struct Entry
{
    public int Value;
    public Entry(int unused) : this() { Value += 173; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry item = new Entry(0);
        Check(item.Value == 173, "initializer-before-field-read");
        Entry plain = new Entry();
        Check(plain.Value == 0, "parameterless-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
