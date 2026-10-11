/*
Rules: E12-19-1-expression-tree-result; E12-19-1-expression-tree-conversion
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: (int value) => value + 47
Into: (int value) => value
*/
using System;
using System.Linq.Expressions;
delegate int Transform(int value);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Expression<Transform> tree = (int value) => value + 47;
        BinaryExpression body = tree.Body as BinaryExpression;
        Check(tree.NodeType == ExpressionType.Lambda && tree.ReturnType == typeof(int), "lambda-object-structure");
        bool addition = body != null && body.NodeType == ExpressionType.Add &&
                        object.ReferenceEquals(body.Left, tree.Parameters[0]);
        Check(addition, "addition-with-declared-parameter-node");
        ConstantExpression constant = body == null ? null : body.Right as ConstantExpression;
        Check(constant != null && constant.Value is int && (int)constant.Value == 47, "constant-node-is-represented");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
