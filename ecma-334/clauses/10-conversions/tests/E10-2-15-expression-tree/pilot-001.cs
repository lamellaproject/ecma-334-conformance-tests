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


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Expression<Func<int,long>> tree=x=>x+61L;
        var sum=(BinaryExpression)tree.Body;
        var widen=(UnaryExpression)sum.Left;
        Check(tree.NodeType==ExpressionType.Lambda && sum.NodeType==ExpressionType.Add && widen.NodeType==ExpressionType.Convert, "E10-2-15-expression-tree-pilot-001-check-01");
        Check(ReferenceEquals(widen.Operand,tree.Parameters[0]) && (long)((ConstantExpression)sum.Right).Value==61 && tree.Compile()(1)==62, "E10-2-15-expression-tree-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
