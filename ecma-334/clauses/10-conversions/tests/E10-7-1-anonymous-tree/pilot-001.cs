/*
Rules: E10-7-1-anonymous-tree
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: reject
Mutate: Expression<Action> result=delegate {};
Into: Expression<Action> result=default(Expression<Action>);
Csc: CS1946
*/
using System;
using System.Linq.Expressions;


class Program
{
    static void Main()
    {
        Expression<Action> result=delegate {};
    }
}
