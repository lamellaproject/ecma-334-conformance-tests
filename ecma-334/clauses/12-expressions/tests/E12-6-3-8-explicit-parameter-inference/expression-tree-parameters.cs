/*
Rules: E12-6-3-8-explicit-parameter-inference
Authority: ECMA-334 7th ed 12.6.3.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (int value) => value + 3L
Into: (long value) => value + 3L
*/
using System;
using System.Linq.Expressions;
class Program
{
    static int checks, failures;
    static Expression<Func<T, long>> Make<T>(Expression<Func<T, long>> f) { return f; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Expression<Func<int, long>> expression = Make((int value) => value + 3L);
        Check(expression.Compile()(6) == 9L, "expression-tree-input-and-output-types-inferred");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
