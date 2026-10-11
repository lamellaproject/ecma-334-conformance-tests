/*
Rules: E12-6-6-2-boxed-interface; E12-6-6-2-boxed-variable-this
Authority: ECMA-334 7th ed 12.6.6.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: box.Advance(4)
Into: original.Advance(4)
*/
using System;
interface ICell { int Advance(int amount); }
struct Cell : ICell
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
        ICell box = original;
        int result = box.Advance(4);
        Check(result == 7, "interface-receiver-invokes-struct-implementation");
        Check(((Cell)box).value == 7, "interface-this-modifies-variable-in-box");
        Check(original.value == 3, "boxed-interface-call-does-not-change-source-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
