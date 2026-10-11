/*
Rules: E10-7-1-overload-inference
Authority: ECMA-334 7th ed 10.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int selected=Bridge.Pick((int x)=>x+1);
Into: int selected=default(int);
*/
using System;


static class Bridge {
    public static int Pick(Func<int,int> f){return f(61);}
    public static int Pick(Func<string,int> f){return f("wrong");}
    public static U Project<T,U>(T value,Func<T,U> f){return f(value);}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selected=Bridge.Pick((int x)=>x+1);
        long projected=Bridge.Project(61,x=>(long)x+2);
        Check(selected==62 && projected==63, "E10-7-1-overload-inference-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
