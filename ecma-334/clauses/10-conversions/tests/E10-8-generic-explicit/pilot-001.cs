/*
Rules: E10-8-generic-explicit; E10-8-generic-inferred; E10-8-generic-runtime; E10-8-overload-inference; E10-8-static-target; E10-8-reuse
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Func<int,int> explicitType=Bridge.Identity<int>, inferred=Bridge.Identity;
Into: Func<int,int> explicitType=default(Func<int,int>), inferred=Bridge.Identity;
*/
using System;


static class Bridge {
    public static T Identity<T>(T x){return x;}
    public static U Project<T,U>(T x,Func<T,U> f){return f(x);}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<int,int> explicitType=Bridge.Identity<int>, inferred=Bridge.Identity;
        Func<int,int> a=Bridge.Identity<int>, b=Bridge.Identity<int>;
        int projected=Bridge.Project(61,Bridge.Identity);
        Check(explicitType(61)==61 && inferred(82)==82 && projected==61 && explicitType.Target==null && a(3)==3 && b(4)==4, "E10-8-generic-explicit-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
