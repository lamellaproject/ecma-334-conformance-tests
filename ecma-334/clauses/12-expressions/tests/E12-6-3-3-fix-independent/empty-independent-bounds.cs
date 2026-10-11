/*
Rules: E12-6-3-3-fix-independent
Authority: ECMA-334 7th ed 12.6.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Select(() => 6)
Into: Select(() => 6M)
*/
using System;
class Program
{
    static int checks, failures;
    static int Select<T>(Func<T> function) { return typeof(T) == typeof(int) ? 1 : 3; }
    static int Select(Func<long> function) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // 12.6.3.3, pp. 169-170 fixes independent variables; 12.6.3.12, p. 172 fixes
    // a variable with bounds. Fixing an empty set would fail every unbounded output inference.
    // This test follows the intent: ready output inference provides bounds before fixing T.
    static void Main()
    {
        int selected = Select(() => 6);
        Check(selected == 1, "output-inference-bounds-independent-variable");
        Check(selected != 2, "generic-int-return-is-better-than-long-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
