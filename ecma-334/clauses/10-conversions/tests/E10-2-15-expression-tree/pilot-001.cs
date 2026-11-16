/*
Rules: E10-2-15-expression-tree; E10-7-1-expression-tree; E10-7-3-structure; E10-7-3-restrictions; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: tree=x=>x+61L;
Into: tree=x=>x+60L;
*/
using System;
using System.Linq.Expressions;

delegate long Add(int value);

class Program
{
    static int checks, failures;
    static int input;
    static int Next() { return ++input; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Expression<Add> tree=x=>x+61L;
        Add compiled=tree.Compile();
        Check(compiled(Next())==62L, "E10-2-15-expression-tree-pilot-001-check-01");
        Check(compiled(Next())==63L, "E10-2-15-expression-tree-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
