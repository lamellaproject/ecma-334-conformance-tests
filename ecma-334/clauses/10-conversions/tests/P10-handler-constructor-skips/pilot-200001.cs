/*
Rules: P10-handler-constructor-skips; P10-handler-append-skips
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 2
Mutate: Gate h=$"a{Skip.Next()}b{Skip.Next()}";
Into: Gate h=default(Gate);
*/
using System;


static class Skip {public static bool Allowed;public static int Holes;public static int Constructions;public static int Next(){Holes++;return 331;}}
[System.Runtime.CompilerServices.InterpolatedStringHandler]
struct Gate {
    public int Appends;
    public Gate(int length,int holes,out bool enabled){Skip.Constructions++;Appends=0;enabled=Skip.Allowed;}
    public bool AppendLiteral(string text){Appends++;return false;}
    public bool AppendFormatted(int x){Appends++;return true;}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Skip.Allowed=false; Skip.Holes=0; Skip.Constructions=0; Gate h=$"a{Skip.Next()}b{Skip.Next()}";
        Check(Skip.Constructions==1 && Skip.Holes==0 && h.Appends==0, "P10-handler-constructor-skips-pilot-200001-check-01");
        Skip.Allowed=true; h=$"a{Skip.Next()}b{Skip.Next()}";
        Check(Skip.Constructions==2 && h.Appends==1 && Skip.Holes==0, "P10-handler-constructor-skips-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
