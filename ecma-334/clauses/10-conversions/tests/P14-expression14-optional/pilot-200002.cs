/*
Rules: P14-expression14-optional
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: reject
Mutate: System.Linq.Expressions.Expression<Func<int>> named=()=>Methods.Sum(b:463,a:467);
Into: System.Linq.Expressions.Expression<Func<int>> named=default(System.Linq.Expressions.Expression<Func<int>>);
*/
using System;

static class Methods{public static int Sum(int a,int b=19)=>a+b;}
class Program
{
    static void Main()
    {
        System.Linq.Expressions.Expression<Func<int>> named=()=>Methods.Sum(b:463,a:467);
    }
}
