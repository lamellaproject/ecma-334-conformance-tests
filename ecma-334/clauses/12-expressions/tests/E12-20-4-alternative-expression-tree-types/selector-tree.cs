/*
Rules: E12-20-4-alternative-expression-tree-types
Authority: ECMA-334 7th ed 12.20.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: select item + 13
Into: select item - 13
*/
using System;
using System.Linq.Expressions;
delegate int Selector(int item);
class TreeSource
{
    public Expression<Selector> Select(Expression<Selector> selector) { return selector; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var tree = from item in new TreeSource() select item + 13;
        Check(tree.Parameters.Count == 1 && tree.Parameters[0].Type == typeof(int), "tree-parameter");
        Check(tree.Body.NodeType == ExpressionType.Add, "tree-operator");
        var binary = tree.Body as BinaryExpression;
        Check(binary != null && object.ReferenceEquals(binary.Left, tree.Parameters[0]), "tree-range-reference");
        var constant = binary == null ? null : binary.Right as ConstantExpression;
        Check(constant != null && (int)constant.Value == 13, "tree-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
