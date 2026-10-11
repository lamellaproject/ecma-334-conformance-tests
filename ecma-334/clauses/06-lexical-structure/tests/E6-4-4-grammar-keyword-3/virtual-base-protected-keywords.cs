/*
Rules: E6-4-4-grammar-keyword-3; E6-4-4-grammar-keyword-74; E6-4-4-grammar-keyword-49
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: base.Read()
Into: Read()
*/
using System;
class Root
{
    protected int seed = 5;
    public virtual int Read() { return seed; }
}
class Leaf : Root
{
    public int visits;
    // Bound recursion if a compiler turns the base call into a virtual call.
    public override int Read() { visits++; if (visits > 2) return -100; return base.Read() + 3; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Leaf item = new Leaf();
        Check(item.Read() == 8, "base-call");
        Check(item.visits == 1, "base-call-does-not-dispatch-to-override");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
