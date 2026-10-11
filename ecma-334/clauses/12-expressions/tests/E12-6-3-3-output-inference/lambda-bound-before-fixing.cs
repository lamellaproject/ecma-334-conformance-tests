/*
Rules: E12-6-3-3-output-inference; E12-6-3-3-fix-independent
Authority: ECMA-334 7th ed 12.6.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Select(1, () => 2L)
Into: Select(1, () => 2)
*/
using System;
class Program
{
    static int checks, failures;
    static int Select<T>(T value, Func<T> function) { return typeof(T) == typeof(long) ? 1 : 3; }
    static int Select(object value, Func<long> function) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    // 12.6.3.3, pp. 169-170 places fixing before ready output inference. That literal order
    // would fix T to int before the lambda's long result contributes its bound.
    // This test follows the intent: perform ready output inference first, then fix T = long.
    static void Main()
    {
        int selected = Select(1, () => 2L);
        Check(selected == 1, "lambda-return-bound-arrives-before-fixing");
        Check(selected != 2, "generic-long-is-better-than-object-fallback");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
