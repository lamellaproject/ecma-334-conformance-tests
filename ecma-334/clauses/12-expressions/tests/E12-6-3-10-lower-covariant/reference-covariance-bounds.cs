/*
Rules: E12-6-3-10-lower-covariant
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Producer<object>()
Into: new Producer<string>()
*/
using System;
interface Output<out T> { }
class Producer<T> : Output<T> { }
class Result<T> { }
class Program
{
    static int checks, failures;
    static Result<T> Common<T>(Output<T> left, Output<T> right) { return new Result<T>(); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<object> result = Common(new Producer<string>(), new Producer<object>());
        Check(result != null, "covariant-reference-components-infer-object-lower-bound");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
