/*
Rules: P12-collection-escape
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: Values(int n)=>[n,197];
Into: Values(int n)=>new int[]{n,197};
*/
using System;

static class CollectionReturn{public static ReadOnlySpan<int> Values(int n)=>[n,197];}
class Program
{
    static void Main()
    {

    }
}
