/*
Rules: P14-expression14-optional
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: run
Stdout: OK 1
Mutate: System.Linq.Expressions.Expression<Func<int>> optional=()=>Methods.Sum(457);
Into: System.Linq.Expressions.Expression<Func<int>> optional=default(System.Linq.Expressions.Expression<Func<int>>);
*/
using System;

static class Methods{public static int Sum(int a,int b=19)=>a+b;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        System.Linq.Expressions.Expression<Func<int>> optional=()=>Methods.Sum(457); System.Linq.Expressions.Expression<Func<int>> named=()=>Methods.Sum(a:467,b:463); Check(optional.Compile()()==476 && named.Compile()()==930, "P14-expression14-optional-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
