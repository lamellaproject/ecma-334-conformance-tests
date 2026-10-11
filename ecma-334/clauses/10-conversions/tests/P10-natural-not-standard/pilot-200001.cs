/*
Rules: P10-natural-not-standard
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Target t=(int x)=>x;
Into: Target t=default(Target);
*/
using System;

class Target{public static implicit operator Target(Delegate x)=>new Target();}
class Program
{
    static void Main()
    {
        Target t=(int x)=>x;
    }
}
