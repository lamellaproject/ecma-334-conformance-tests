/*
Rules: P08-static-local-no-expression-tree
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: reject
Mutate: Expression<Func<int>> probe = () => Read();
Into: Func<int> probe = () => Read();
*/
using System;
using System.Linq.Expressions;
class Program
{
    static int Main()
    {
        static int Read() { return 67; }
        Expression<Func<int>> probe = () => Read();
        return probe == null ? 1 : 0;
    }
}
