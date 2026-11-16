/*
Rules: P09-funcptr-convention
Authority: csc 5.12.0-1.26529.118 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: delegate* unmanaged[Cdecl]<int,int> q
Into: delegate*<int,int> q
*/
using System;

static class Address{public static int Apply(int x)=>x;}
class Program
{
    static void Main()
    {
        unsafe {delegate*<int,int> p=&Address.Apply;delegate* unmanaged[Cdecl]<int,int> q=p;}
    }
}
