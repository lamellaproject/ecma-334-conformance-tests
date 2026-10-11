/*
Rules: P13-method13-prune; P13-method13-scopes
Authority: csc 5.11.0-1.26425.128 (C# 13.0)
Version: 13.0
Expected: run
Stdout: OK 1
Mutate: Receiver r=new Receiver();
Into: Receiver r=default(Receiver);
*/
using System;


static class Methods {public static int Apply(int x)=>x+31;public static T Apply<T>(T x)=>x;public static T Generic<T>(T x) where T:class=>x;public static int Generic<T>(int x) where T:struct=>x;}
class Receiver {public int Read(int x)=>x+37;}
static class Outer {public static long Read(this Receiver r,long x)=>x+41;}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var a=Methods.Apply; var b=Methods.Generic<string>;
        Receiver r=new Receiver(); var bound=r.Read;
        Check(a(353)==384 && b("obsidian")=="obsidian" && bound(359)==396, "P13-method13-prune-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
