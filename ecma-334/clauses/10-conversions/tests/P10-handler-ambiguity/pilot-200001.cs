/*
Rules: P10-handler-ambiguity
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: Pick($"{n}")
Into: Pick((One)$"{n}")
*/
using System;
using System.Runtime.CompilerServices;
[InterpolatedStringHandler] struct One{public One(int l,int c){}public void AppendFormatted(int n){}}
[InterpolatedStringHandler] struct Two{public Two(int l,int c){}public void AppendFormatted(int n){}}
class Program {static void Pick(One h){}static void Pick(Two h){}static void Main(){int n=347;Pick($"{n}");}}
