/*
Rules: E18-6-1-struct-implementation
Authority: ECMA-334 7th ed 18.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: struct Value : IBranch
Into: struct Value
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    interface IRoot { int Read(); }
    interface IBranch : IRoot { }
    struct Value : IBranch { public int Read() { return 47; } }
    static int Main()
    {
        IBranch branch = new Value();
        IRoot root = branch;
        Check(root.Read() == 47, "struct-implements-inherited-contract");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
