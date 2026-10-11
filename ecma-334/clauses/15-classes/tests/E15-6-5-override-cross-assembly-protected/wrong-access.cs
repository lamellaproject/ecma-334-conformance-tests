/*
Rules: E15-6-5-override-cross-assembly-protected
Authority: ECMA-334 7th ed 15.6.5
Version: 7.3
Expected: reject
Mutate: protected internal override Expression VisitChildren(ExpressionVisitor visitor)
Into: protected override Expression VisitChildren(ExpressionVisitor visitor)
Csc: CS0507
*/
using System.Linq.Expressions;
class Node : Expression
{
    protected internal override Expression VisitChildren(ExpressionVisitor visitor) { return this; }
}
class Program { static void Main() { } }
