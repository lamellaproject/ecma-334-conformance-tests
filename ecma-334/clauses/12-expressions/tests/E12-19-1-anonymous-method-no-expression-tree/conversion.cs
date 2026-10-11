/*
Rules: E12-19-1-anonymous-method-no-expression-tree
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: reject
Mutate: delegate(int value) { return value + 67; }
Into: (int value) => value + 67
*/
using System.Linq.Expressions;
delegate int Transform(int item);
class Program { static void Main() { Expression<Transform> tree = delegate(int value) { return value + 67; }; } }
