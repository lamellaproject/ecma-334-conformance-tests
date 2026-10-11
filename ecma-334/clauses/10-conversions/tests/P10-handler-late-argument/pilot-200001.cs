/*
Rules: P10-handler-late-argument
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Sink.Read($"{n}",n)
Into: Sink.Read(n:n,h:$"{n}")
*/
using System;


[System.Runtime.CompilerServices.InterpolatedStringHandler] struct Routed {public Routed(int l,int c,int n){}public void AppendFormatted(int x){}}
static class Sink {public static void Read([System.Runtime.CompilerServices.InterpolatedStringHandlerArgument("n")] Routed h,int n){}}

class Program
{
    static void Main()
    {
        int n=373; Sink.Read($"{n}",n);
    }
}
