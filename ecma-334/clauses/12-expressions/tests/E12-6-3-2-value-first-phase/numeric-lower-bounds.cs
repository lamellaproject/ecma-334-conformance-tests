/*
Rules: E12-6-3-2-value-first-phase; E12-6-3-10-lower-bound; E12-6-3-12-fixing-candidates; E12-6-3-12-fixing-lower-filter; E12-6-3-12-fixing-result
Authority: ECMA-334 7th ed 12.6.3.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Common(3, 19L)
Into: Common(3, 19M)
*/
using System;
class Result<T> { public T value; }
class Program
{
    static int checks, failures;
    static Result<T> Common<T>(T first, T second) { return new Result<T> { value = second }; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result<long> result = Common(3, 19L);
        Check(result.value == 19L, "long-is-unique-candidate-accepting-both-lower-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
