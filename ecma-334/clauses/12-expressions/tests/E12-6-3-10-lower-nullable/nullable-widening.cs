/*
Rules: E12-6-3-10-lower-nullable
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Merge((int?)3, (long?)15)
Into: Merge((int?)3, (decimal?)15)
*/
using System;
class Result<T> where T : struct { public T? value; }
class Program
{
    static int checks, failures;
    static Result<T> Merge<T>(T? left, T? right) where T : struct { return new Result<T> { value = right }; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<long> result = Merge((int?)3, (long?)15);
        Check(result.value == 15L, "nullable-underlying-types-contribute-lower-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
