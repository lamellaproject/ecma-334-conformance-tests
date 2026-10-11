/*
Rules: P11-checked-udc-trees
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 1
Mutate: System.Linq.Expressions.Expression<Func<Measured,int>> tree=x=>checked((int)x);
Into: System.Linq.Expressions.Expression<Func<Measured,int>> tree=default(System.Linq.Expressions.Expression<Func<Measured,int>>);
*/
using System;


struct Measured {
    public int Code;
    public static explicit operator int(Measured x)=>x.Code+79;
    public static explicit operator checked int(Measured x)=>x.Code+83;
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        System.Linq.Expressions.Expression<Func<Measured,int>> tree=x=>checked((int)x); var node=(System.Linq.Expressions.UnaryExpression)tree.Body; Check(node.Method.Name=="op_CheckedExplicit" && tree.Compile()(new Measured{Code=277})==360, "P11-checked-udc-trees-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
