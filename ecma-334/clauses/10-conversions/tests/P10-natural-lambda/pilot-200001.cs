/*
Rules: P10-natural-lambda; P10-natural-method; P10-natural-base; P10-natural-var; P10-natural-action; P10-natural-func
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: Delegate d=(int x)=>x+43;
Into: Delegate d=default(Delegate);
*/
using System;

static class Natural {public static int Last;public static int Apply(int x)=>x+31;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var natural=(int x)=>x+37; var group=Natural.Apply;
        Delegate d=(int x)=>x+43; MulticastDelegate m=(int x)=>x+47;
        object o=Natural.Apply; ICloneable clone=(int x)=>x+53;
        var voidFunction=(int x)=>Natural.Last=x;
        voidFunction(199);
        Check(natural.GetType()==typeof(Func<int,int>) && natural(211)==248 && group(223)==254, "P10-natural-lambda-pilot-200001-check-01");
        Check((int)d.DynamicInvoke(227)==270 && (int)m.DynamicInvoke(229)==276, "P10-natural-lambda-pilot-200001-check-02");
        Check((int)((Delegate)o).DynamicInvoke(233)==264 && (int)((Delegate)clone).DynamicInvoke(239)==292, "P10-natural-lambda-pilot-200001-check-03");
        Check(Natural.Last==199, "P10-natural-lambda-pilot-200001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
