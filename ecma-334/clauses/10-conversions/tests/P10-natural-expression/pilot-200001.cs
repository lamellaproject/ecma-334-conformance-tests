/*
Rules: P10-natural-expression
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 1
Mutate: System.Linq.Expressions.Expression tree=(int x)=>x+59;
Into: System.Linq.Expressions.Expression tree=default(System.Linq.Expressions.Expression);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        System.Linq.Expressions.Expression tree=(int x)=>x+59; System.Linq.Expressions.LambdaExpression lambda=(int x)=>x+61; Check((int)((System.Linq.Expressions.LambdaExpression)tree).Compile().DynamicInvoke(251)==310 && (int)lambda.Compile().DynamicInvoke(257)==318, "P10-natural-expression-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
