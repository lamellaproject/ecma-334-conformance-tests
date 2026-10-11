/*
Rules: E12-6-3-13-async-nothing-return
Authority: ECMA-334 7th ed 12.6.3.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Make(0, async x => Touch())
Into: Make(0, x => Touch())
*/
using System;
using System.Threading.Tasks;
class Program
{
    static int checks, failures, touched;
    static void Touch() { touched++; }
    static T Make<P, T>(P seed, Func<P, T> f) { return f(seed); }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Task expression = Make(0, async x => Touch());
        Task block = Make(0, async x => { Touch(); });
        Check(expression.IsCompleted && touched == 2, "void-expression-infers-nongeneric-task");
        Check(block.IsCompleted, "no-return-expressions-infers-nongeneric-task");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
