/*
Rules: E15-2-4-2-constructed-base-substitution; E15-2-4-2-base-in-scope-parameters
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public class Leaf : Root<T>
Into: public class Leaf : Root<object>
*/
using System;
class Root<T> { public T Value; }
class Crate<T> { public class Leaf : Root<T> { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Crate<int>.Leaf leaf = new Crate<int>.Leaf();
        leaf.Value = 229;
        Root<int> root = leaf;
        Check(root.Value == 229, "nested-base-uses-containing-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
