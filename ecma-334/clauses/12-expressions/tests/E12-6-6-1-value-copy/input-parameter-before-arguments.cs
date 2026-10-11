/*
Rules: E12-6-6-1-value-copy; E12-6-6-1-value-arguments; E12-6-6-1-value-mutation-observable
Authority: ECMA-334 7th ed 12.6.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: receiver.Advance(Argument())
Into: original.Advance(Argument())
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
    static int Argument() { original.value = 9; return 4; }
    static int Invoke(in Cell receiver) { return receiver.Advance(Argument()); }
    static void Main()
    {
        int result = Invoke(in original);
        Check(result == 7, "input-receiver-copied-before-argument-changes-source");
        Check(original.value == 9, "method-modifies-copy-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
