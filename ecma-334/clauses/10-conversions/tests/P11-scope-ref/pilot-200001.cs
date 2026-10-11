/*
Rules: P11-scope-ref; P11-scope-value; P11-scope-out; P11-scope-refstruct
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 3
Mutate: SpanReader lambda=(scoped Span<int> x)=>x.Length;
Into: SpanReader lambda=default(SpanReader);
*/
using System;


delegate int RefReader(ref int n); delegate int SpanReader(Span<int> x);
delegate void OutReader([System.Diagnostics.CodeAnalysis.UnscopedRef] out Span<int> x);
delegate int RefSpanReader([System.Diagnostics.CodeAnalysis.UnscopedRef] ref Span<int> x);
static class Readers{
    public static int Read(scoped ref int n)=>n;
    public static int Sum(scoped Span<int> x)=>x[0]+x[1];
    public static void Fill(out Span<int> x){x=Span<int>.Empty;}
    public static int First(ref Span<int> x)=>x[0];
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        RefReader a=Readers.Read; SpanReader b=Readers.Sum; OutReader c=Readers.Fill; RefSpanReader d=Readers.First;
        int n=521; Span<int> span=stackalloc int[]{523,541};
        Check(a(ref n)==521 && b(span)==1064 && d(ref span)==523, "P11-scope-ref-pilot-200001-check-01");
        c(out span); Check(span.IsEmpty, "P11-scope-ref-pilot-200001-check-02");
        SpanReader lambda=(scoped Span<int> x)=>x.Length; Check(lambda(span)==0, "P11-scope-ref-pilot-200001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
