/*
Rules: E12-6-3-11-upper-contravariant
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Consumer<Input<object>>()
Into: new Consumer<Input<string>>()
*/
using System;
interface Input<in T> { }
class Consumer<T> : Input<T> { }
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Common<T>(Input<Input<T>> a, Input<Input<T>> b) { return new Result<T>(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<object> result = Common(new Consumer<Input<object>>(), new Consumer<Input<string>>());
        Check(result != null, "upper-contravariant-component-produces-lower-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
