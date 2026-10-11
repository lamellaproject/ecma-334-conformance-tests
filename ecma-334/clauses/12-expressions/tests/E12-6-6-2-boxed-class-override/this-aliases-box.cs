/*
Rules: E12-6-6-2-boxed-class-override; E12-6-6-2-boxed-variable-this
Authority: ECMA-334 7th ed 12.6.6.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: box.ToString()
Into: original.ToString()
*/
using System;
struct Cell
{
    public int value;
    public override string ToString() { value++; return value == 4 ? "first" : "later"; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell original = new Cell { value = 3 };
        object box = original;
        string result = box.ToString();
        Check(result == "first", "object-receiver-invokes-struct-override");
        Check(((Cell)box).value == 4, "override-this-modifies-variable-in-box");
        Check(original.value == 3, "boxed-override-does-not-change-source-struct");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
