/*
Rules: E15-6-5-override-cross-assembly-protected
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: protected override Expression VisitChildren(ExpressionVisitor visitor)
Into: protected new Expression VisitChildren(ExpressionVisitor visitor)
*/
using System;
using System.Linq.Expressions;
class Node : Expression
{
    public int Calls;
    protected override Expression VisitChildren(ExpressionVisitor visitor) { Calls++; return this; }
}
class Visitor : ExpressionVisitor { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Node node = new Node();
        Expression result = null;
        bool completed = false;
        try { result = new Visitor().Visit(node); completed = true; }
        catch (Exception) { }
        Check(completed, "protected-override-of-external-protected-internal-method-executes");
        Check(result == node && node.Calls == 1, "external-library-dispatch-selects-source-override-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
