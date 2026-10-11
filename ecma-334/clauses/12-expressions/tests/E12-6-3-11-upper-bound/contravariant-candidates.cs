/*
Rules: E12-6-3-11-upper-bound; E12-6-3-10-lower-contravariant; E12-6-3-12-fixing-upper-filter
Authority: ECMA-334 7th ed 12.6.3.11
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Consumer<string>()
Into: new Consumer<object>()
*/
using System;
interface Input<in T> { }
class Consumer<T> : Input<T> { }
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Common<T>(Input<T> left, Input<T> right) { return new Result<T>(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<string> result = Common(new Consumer<string>(), new Consumer<object>());
        Check(result != null, "string-is-only-candidate-convertible-to-both-upper-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
