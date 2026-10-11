/*
Rules: E12-6-3-11-upper-constructed-shape; E12-6-3-11-upper-covariant
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Consumer<Output<string>>()
Into: new Consumer<Output<object>>()
*/
using System;
interface Input<in T> { }
interface Output<out T> { }
class Producer<T> : Output<T> { }
class Consumer<T> : Input<T> { }
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Common<T>(Input<Producer<T>> a, Input<Producer<T>> b) { return new Result<T>(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<string> result = Common(new Consumer<Output<string>>(), new Consumer<Output<object>>());
        Check(result != null, "upper-inference-finds-unique-implemented-generic-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
