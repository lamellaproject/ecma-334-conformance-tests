/*
Rules: E15-6-9-partial-unimplemented-no-expression-tree
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: static partial void Record();
Into: static partial void Record(); static partial void Record() { }
Csc: CS0765
*/
using System;
using System.Linq.Expressions;
partial class Program
{
    static partial void Record();
    static void Main() { Expression<Action> action = () => Record(); }
}
