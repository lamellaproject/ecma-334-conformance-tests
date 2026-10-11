/*
Rules: E6-4-4-grammar-keyword-21; E6-4-4-grammar-keyword-16; E6-4-4-grammar-contextual-keyword-1; E6-4-4-grammar-contextual-keyword-21; E6-4-4-grammar-contextual-keyword-25
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: event Pulse Changed
Into: Pulse Changed
*/
using System;
delegate void Pulse();
class Tap
{
    public int Balance;
    public event Pulse Changed
    {
        add { if (value != null) Balance++; }
        remove { if (value != null) Balance--; }
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Touch() { }
    static void Main()
    {
        Tap item = new Tap();
        Pulse handler = Touch;
        item.Changed += handler;
        Check(item.Balance == 1, "event-add");
        item.Changed -= handler;
        Check(item.Balance == 0, "event-remove");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
