/*
Rules: P09-new-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: new(197)
Into: new(0)
*/
using System;
class Widget
{
    public int Code;
    public Widget(int value) { Code = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Widget result = new(197);
        Check(result.Code == 197, "constructor/target-type-and-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
