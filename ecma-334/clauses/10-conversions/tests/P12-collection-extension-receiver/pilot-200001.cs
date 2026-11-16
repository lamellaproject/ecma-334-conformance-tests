/*
Rules: P12-collection-extension-receiver
Authority: csc 5.12.0-1.26529.118 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: int n=[13,17].Size();
Into: int n=default(int);
*/
using System;

static class Ext{public static int Size(this int[] x)=>x.Length;}
class Program
{
    static void Main()
    {
        int n=[13,17].Size();
    }
}
