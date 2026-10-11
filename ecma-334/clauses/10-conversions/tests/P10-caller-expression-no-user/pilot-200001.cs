/*
Rules: P10-caller-expression-no-user
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Text text=default
Into: string text=null
*/
using System;

struct Text{public static implicit operator Text(string x)=>default;}static class Caller{public static void Read(int n,[System.Runtime.CompilerServices.CallerArgumentExpression("n")] Text text=default){}}
class Program
{
    static void Main()
    {
        Caller.Read(557);
    }
}
