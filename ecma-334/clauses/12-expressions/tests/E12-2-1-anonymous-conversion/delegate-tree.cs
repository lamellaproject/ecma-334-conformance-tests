/*
Rules: E12-2-1-anonymous-conversion
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: n => n + 4
Into: n => n - 4
*/
using System;
using System.Linq.Expressions;
class Program
{
    delegate int Transform(int n);
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Transform direct = n => n + 4;
        Expression<Transform> tree = n => n * 3;
        Check(direct(7) == 11, "delegate-target");
        Check(tree.Compile()(5) == 15, "expression-tree-target");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
