/*
Rules: E8-7-dynamic-inference-preference
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Box<dynamic> first = new Box<dynamic>();
Into: Box<object> first = new Box<object>();
*/
using System;
public class Receiver { public int Read() { return 46; } }
class Box<T> { public T Item; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static T Choose<T>(T first, T second) { return first; }
    static void Main()
    {
        Box<dynamic> first = new Box<dynamic>(); first.Item = new Receiver();
        Box<object> second = new Box<object>(); second.Item = new object();
        var merged = Choose(first, second);
        Check((int)merged.Item.Read() == 46, "inferred-constructed-argument-prefers-dynamic");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
