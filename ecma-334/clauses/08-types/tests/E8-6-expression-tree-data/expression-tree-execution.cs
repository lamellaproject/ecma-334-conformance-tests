/*
Rules: E8-6-expression-tree-data; E8-6-expression-tree-type; E8-6-lambda-expression-tree-conversion; E8-6-lambda-delegate-executable; E8-6-lambda-expression-tree-representation; E8-6-expression-tree-compile; E8-6-compiled-expression-tree-execution
Authority: ECMA-334 7th ed 8.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: System.Linq.Expressions.Expression<Produce> tree = () => Touch();
Into: System.Linq.Expressions.Expression<Produce> tree = () => 47;
*/
using System;
delegate int Produce();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int calls;
    static int Touch() { calls++; return 45 + calls; }
    static void Main()
    {
        Produce direct = () => Touch();
        System.Linq.Expressions.Expression<Produce> tree = () => Touch();
        Check(calls == 0, "conversion-stores-structure-without-execution");
        Produce compiled = tree.Compile();
        Check(direct() == 46 && compiled() == 47, "compiled-tree-executes-lambda-code");
        Check(calls == 2, "both-delegates-executed-their-bodies");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
