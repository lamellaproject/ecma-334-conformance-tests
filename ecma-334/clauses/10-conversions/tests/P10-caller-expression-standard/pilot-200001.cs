/*
Rules: P10-caller-expression-standard
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 1
Mutate: Caller.Read(n+2)
Into: Caller.Read(n+2,"wrong")
*/
using System;

static class Caller{public static string Read(int n,[System.Runtime.CompilerServices.CallerArgumentExpression("n")] object text=null)=>(string)text;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int n=547; Check(Caller.Read(n+2)=="n+2", "P10-caller-expression-standard-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
