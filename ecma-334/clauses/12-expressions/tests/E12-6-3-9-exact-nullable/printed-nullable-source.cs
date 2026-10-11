/*
Rules: E12-6-3-9-exact-nullable
Authority: ECMA-334 7th ed 12.6.3.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Inspect((int? x) => 1)
Into: Inspect((long? x) => 1)
*/
using System;
class Program
{
    static int checks, failures;
    static int Inspect<T>(Func<T?, int> function) where T : struct { return typeof(T) == typeof(int) ? 1 : 3; }
    static int Inspect(Func<int?, long> function) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // 12.6.3.9, pp. 170-171 prints "U is the type U1"; the parallel lower- and upper-bound
    // rules in 12.6.3.10-12.6.3.11, pp. 171-172 print U1?. Literal inference would make T?
    // an invalid nested nullable type. This test follows the intent U1?, yielding T = int.
    static void Main()
    {
        int selected = Inspect((int? x) => 1);
        Check(selected == 1, "nullable-source-exactly-infers-underlying-int");
        Check(selected != 2, "generic-int-result-is-better-than-long-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
