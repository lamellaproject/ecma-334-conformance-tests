/*
Rules: E12-6-6-1-value-copy; E12-6-6-1-value-copy-reclassification; E12-6-6-1-value-mutation-observable
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static ref readonly Cell Receiver()
Into: static ref Cell Receiver()
*/
using System;
struct Cell
{
    public int value;
    public int Advance(int amount) { value += amount; return value; }
}
class Program
{
    static int checks, failures;
    static Cell original = new Cell { value = 3 };
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref readonly Cell Receiver() { return ref original; }
    static void Main()
    {
        int result = Receiver().Advance(4);
        Check(result == 7, "readonly-return-copy-is-mutable-this");
        Check(original.value == 3, "readonly-return-call-does-not-change-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
