/*
Rules: E12-6-3-11-upper-nullable-shape; E12-6-3-11-upper-unknown-reference
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Consumer<int?>()
Into: new Consumer<long?>()
*/
using System;
interface Input<in T> { }
class Consumer<T> : Input<T> { }
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Observe<T>(Input<T?> x) where T : struct { return new Result<T>(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<int> result = Observe(new Consumer<int?>());
        Check(result != null, "nullable-value-components-infer-exact-underlying-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
