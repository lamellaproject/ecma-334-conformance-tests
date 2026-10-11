/*
Rules: P12-readonly-method-compatible
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 2
Mutate: InReader lambda=(ref readonly int x)=>x+31;
Into: InReader lambda=default(InReader);
*/
using System;


delegate int RefReader(ref int n); delegate int InReader(in int n); delegate int ReadonlyReader(ref readonly int n);
static class Readers {public static int Read(ref readonly int x)=>x+23;public static int In(in int x)=>x+29;}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        RefReader a=Readers.Read; InReader b=Readers.Read; ReadonlyReader c=Readers.In; RefReader d=Readers.In;
        int n=347; Check(a(ref n)==370 && b(in n)==370 && c(in n)==376 && d(ref n)==376, "P12-readonly-method-compatible-pilot-200001-check-01");
        InReader lambda=(ref readonly int x)=>x+31; Check(lambda(in n)==378, "P12-readonly-method-compatible-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
