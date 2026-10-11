/*
Rules: E12-6-3-3-repeat-second-phase; E12-6-3-1-inference-phases; E12-6-3-1-equivalent-algorithm; E12-6-3-3-fix-independent; E12-6-3-3-output-inference; E12-6-3-4-input-types; E12-6-3-5-output-types; E12-6-3-6-direct-dependence; E12-6-3-6-transitive-dependence; E12-6-3-7-anonymous-output; E12-6-3-13-known-parameter-types; E12-6-3-13-effective-expression-return; E12-6-3-13-synchronous-return
Authority: ECMA-334 7th ed 12.6.3.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: x => new Cell { value = x }
Into: x => x
*/
using System;
class Cell { public int value; }
class Program
{
    static int checks, failures;
    static W Travel<T, U, V, W>(T seed, Func<V, W> last, Func<U, V> middle, Func<T, U> first)
    {
        return last(middle(first(seed)));
    }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        long result = Travel(4, v => v + 1, c => c.value * 2L, x => new Cell { value = x });
        Check(result == 9L, "successive-inputs-fixed-from-output-bounds-in-reverse-source-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
