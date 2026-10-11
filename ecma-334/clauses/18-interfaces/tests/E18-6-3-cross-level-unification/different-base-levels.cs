/*
Rules: E18-6-3-cross-level-unification
Authority: ECMA-334 7th ed 18.6.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: class Branch<T> : Root<T>, ICell<int>
Into: class Branch<T> : Root<T>, ICell<T>, ICell<int>
*/
using System;
interface ICell<T> { }
class Root<T> : ICell<T> { }
class Branch<T> : Root<T>, ICell<int> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Branch<int> same = new Branch<int>();
        Branch<string> different = new Branch<string>();
        Check(same is ICell<int>, "cross-level-constructions-unify");
        Check(different is ICell<int>, "direct-construction");
        Check(different is ICell<string>, "inherited-construction");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
