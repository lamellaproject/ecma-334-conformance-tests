/*
Rules: P12-defaults-ignored; P12-defaults-natural; P12-defaults-unify; P12-defaults-params-unify
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 4
Mutate: Func<int,int> named=(int a=311)=>a+17;
Into: Func<int,int> named=default(Func<int,int>);
*/
using System;

static class DefaultMethods {public static int Apply(int n=337)=>n+17;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var optional=(int a=307)=>a+11; var matching=(int b=307)=>b+13;
        var variadic=(params int[] a)=>a.Length; var other=(params int[] b)=>b.Length+1;
        Func<int,int> named=(int a=311)=>a+17;
        Check(optional()==318 && matching()==320 && optional.GetType()==matching.GetType(), "P12-defaults-ignored-pilot-200001-check-01");
        Check(variadic(313,317)==2 && other()==1 && variadic.GetType()==other.GetType(), "P12-defaults-ignored-pilot-200001-check-02");
        Check(named(331)==348, "P12-defaults-ignored-pilot-200001-check-03");
        var method=DefaultMethods.Apply; Check(method()==354, "P12-defaults-ignored-pilot-200001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
