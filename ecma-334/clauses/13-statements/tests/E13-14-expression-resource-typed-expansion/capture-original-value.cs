/*
Rules: E13-14-expression-resource-typed-expansion; E13-14-form-using-expression-acquisition
Authority: ECMA-334 7th ed 13.14
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (selected)
Into: using (replacement)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    class Resource : IDisposable
    {
        public int Disposed;
        public void Dispose() { Disposed++; }
    }
    static void Main()
    {
        Resource original = new Resource(), replacement = new Resource();
        Resource selected = original;
        using (selected) { selected = replacement; }
        Check(selected == replacement, "expression-does-not-freeze-outer-variable");
        Check(original.Disposed == 1 && replacement.Disposed == 0, "expression-captures-resource-before-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
