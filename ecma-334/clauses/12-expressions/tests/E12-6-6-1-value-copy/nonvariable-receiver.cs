/*
Rules: E12-6-6-1-value-copy; E12-6-6-1-value-copy-reclassification; E12-6-6-1-value-copy-this; E12-6-6-1-value-mutation-observable
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Value.Advance(4)
Into: original.Advance(4)
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
    static Cell Value { get { return original; } }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int result = Value.Advance(4);
        Check(result == 7, "nonvariable-temporary-is-mutable-this");
        Check(original.value == 3, "nonvariable-temporary-does-not-alias-source");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
