/*
Rules: P13-method13-conflict
Authority: csc 5.12.0-1.26529.118 (C# 13.0)
Version: 13.0
Expected: reject
Mutate: var group=Methods.Apply;
Into: Func<int,int> group=Methods.Apply;
*/
using System;

static class Methods{public static int Apply(int x)=>x;public static string Apply(string x)=>x;}
class Program
{
    static void Main()
    {
        var group=Methods.Apply;
    }
}
