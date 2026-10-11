/*
Rules: E12-6-6-2-boxed-delegate; E12-6-6-2-boxed-variable-this
Authority: ECMA-334 7th ed 12.6.6.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: call(4)
Into: original.Advance(4)
*/
using System;
delegate int Advance(int amount);
struct Cell
{
    public int value;
    public int Advance(int amount) { value += amount; return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell original = new Cell { value = 3 };
        Advance call = original.Advance;
        int result = call(4);
        Check(result == 7, "delegate-invokes-struct-member");
        Check(((Cell)call.Target).value == 7, "delegate-this-modifies-boxed-target");
        Check(original.value == 3, "delegate-capture-keeps-source-struct-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
