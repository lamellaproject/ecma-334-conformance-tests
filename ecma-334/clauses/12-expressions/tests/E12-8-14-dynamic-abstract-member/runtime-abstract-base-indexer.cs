/*
Rules: E12-8-14-dynamic-abstract-member
Authority: ECMA-334 7th ed 12.8.14
Version: 7.3
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/runtime-abstract-base-indexer-4029b6f46a.cs.part
Mutate: base[index]
Into: this[index]
*/
using System;
abstract class Root
{
    public abstract int this[int index] { get; }
    public int this[string index] { get { Program.concreteReads++; return 7; } }
}
class Leaf : Root
{
    public override int this[int index] { get { Program.reads++; return index; } }
    public int Read(dynamic index) { return base[index]; }
}
public class Program
{
    public static int reads, concreteReads;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool rejected = false;
        try { new Leaf().Read(3); }
        catch (Exception) { rejected = true; }
        Check(rejected, "abstract-base-indexer-fails-at-runtime-binding");
        Check(reads == 0, "abstract-base-access-never-dispatches-to-derived-getter");
        Check(new Leaf().Read("fir") == 7 && concreteReads == 1, "concrete-base-overload-remains-invocable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
