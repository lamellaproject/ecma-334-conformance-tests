/*
Rules: P09-new-target; P09-new-nullable
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: Widget reference=new(197);
Into: Widget reference=default(Widget);
*/
using System;

class Widget {public int Code;public Widget(int n){Code=n;}} struct Token {public int Code;public Token(int n){Code=n;}}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Widget reference=new(197); Token? value=new(211); (int,int) tuple=new(223,227);
        Check(reference.Code==197 && value.HasValue && value.Value.Code==211 && tuple.Item1+tuple.Item2==450, "P09-new-target-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
