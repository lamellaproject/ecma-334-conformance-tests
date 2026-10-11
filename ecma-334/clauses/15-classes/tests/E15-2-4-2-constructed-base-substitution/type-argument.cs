/*
Rules: E15-2-4-2-constructed-base-substitution; E15-2-4-2-constructed-base; E15-2-4-2-base-in-scope-parameters
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Leaf<U> : Root<U[]>
Into: class Leaf<U> : Root<U>
*/
using System;
class Root<T> { public T Value; }
class Leaf<U> : Root<U[]> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[] { 223, 227 };
        Leaf<int> leaf = new Leaf<int>();
        leaf.Value = values;
        Root<int[]> root = leaf;
        Check(root.Value == values, "constructed-base-argument-substitution");
        Check(root.Value[1] == 227, "constructed-base-member-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
