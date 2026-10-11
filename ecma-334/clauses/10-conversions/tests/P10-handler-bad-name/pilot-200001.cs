/*
Rules: P10-handler-bad-name
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: HandlerArgument("missing")
Into: HandlerArgument("n")
*/
using System;


[System.Runtime.CompilerServices.InterpolatedStringHandler] struct Routed {public Routed(int l,int c,int n){}public void AppendFormatted(int x){}}
static class Sink {public static void Read(int n,[System.Runtime.CompilerServices.InterpolatedStringHandlerArgument("missing")] Routed h){}}

class Program
{
    static void Main()
    {
        Sink.Read(367,$"{367}");
    }
}
