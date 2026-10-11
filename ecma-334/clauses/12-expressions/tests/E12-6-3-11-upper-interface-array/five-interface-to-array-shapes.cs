/*
Rules: E12-6-3-11-upper-interface-array
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: new Consumer<IEnumerable<string>>()
Into: new Consumer<IEnumerable<object>>()
*/
using System;
using System.Collections.Generic;
interface Input<in T> { }
class Consumer<T> : Input<T> { }
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Observe<T>(Input<T[]> x) { return new Result<T>(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<string> a = Observe(new Consumer<IEnumerable<string>>());
        Result<string> b = Observe(new Consumer<ICollection<string>>());
        Result<string> c = Observe(new Consumer<IList<string>>());
        Result<string> d = Observe(new Consumer<IReadOnlyList<string>>());
        Result<string> e = Observe(new Consumer<IReadOnlyCollection<string>>());
        Check(a != null, "enumerable-source-array-target-element-inference");
        Check(b != null, "collection-source-array-target-element-inference");
        Check(c != null, "list-source-array-target-element-inference");
        Check(d != null, "readonly-list-source-array-target-element-inference");
        Check(e != null, "readonly-collection-source-array-target-element-inference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
