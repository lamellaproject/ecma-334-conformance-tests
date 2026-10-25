/*
Rules: P08-coalescing-assignment-storage-result
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: Base slot = null;
Into: Child slot = null;
*/
using System;

class Base { }
class Child : Base { }
class Program
{
    static int checks, failures;
    static int Kind(Base value) { return 1; }
    static int Kind(Child value) { return 2; }
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Base slot = null;
        Child replacement = new Child();
        int kind = Kind(slot ??= replacement);
        Check(kind == 1, "reference-result-has-storage-type");
        Check(Object.ReferenceEquals(slot, replacement), "reference-result-stores-derived-instance");
        object result = (slot ??= new Child());
        Check(Object.ReferenceEquals(result, replacement), "reference-result-retains-resident-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
