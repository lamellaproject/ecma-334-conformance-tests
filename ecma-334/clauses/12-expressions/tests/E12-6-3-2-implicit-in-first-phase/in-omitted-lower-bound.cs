/*
Rules: E12-6-3-2-implicit-in-first-phase
Authority: ECMA-334 7th ed 12.6.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Merge(7L, value)
Into: Merge(7L, in value)
*/
using System;
class Result<T> { public T value; }
class Program
{
    static int checks, failures;
    static Result<T> Merge<T>(T first, in T second) { return new Result<T> { value = second }; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 5;
        Result<long> result = Merge(7L, value);
        Check(result.value == 5L, "omitted-in-contributes-convertible-lower-bound");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
