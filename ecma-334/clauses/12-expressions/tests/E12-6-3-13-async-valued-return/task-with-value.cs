/*
Rules: E12-6-3-13-async-valued-return
Authority: ECMA-334 7th ed 12.6.3.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Make(6, async x => x)
Into: Make(6, x => x)
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures;
    static T Make<P, T>(P seed, Func<P, T> f) { return f(seed); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Task<int> expression = Make(6, async x => x);
        Task<long> block = Make(true, async first => { if (first) return 8; return 11L; });
        Check(expression.IsCompleted && expression.Result == 6, "async-expression-wraps-inferred-value-type");
        Check(block.IsCompleted && block.Result == 8L, "async-block-wraps-best-common-return-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
