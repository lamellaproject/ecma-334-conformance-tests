/*
Rules: E18-6-2-explicit-params-optional
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int ICount.Count(int[] values)
Into: int ICount.Count(long[] values)
*/
using System;
interface ICount { int Count(params int[] values); }
class Plain : ICount { int ICount.Count(int[] values) { return values.Length; } }
class Marked : ICount { int ICount.Count(params int[] values) { return values.Length; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ICount plain = new Plain();
        ICount marked = new Marked();
        Check(plain.Count(2, 3, 5) == 3, "params-omitted-in-implementation");
        Check(marked.Count(7, 11) == 2, "params-included-in-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
