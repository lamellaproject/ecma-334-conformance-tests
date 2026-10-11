/*
Rules: E8-7-dynamic-object-equivalence; E8-7-dynamic-object-identity; E8-7-dynamic-constructed-identity; E8-7-dynamic-object-runtime
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Box<dynamic> first = new Box<dynamic>();
Into: Box<int> first = new Box<int>();
*/
using System;
class Box<T> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Accept(ref Box<object> value) { }
    static void Main()
    {
        Box<dynamic> first = new Box<dynamic>(); Box<object> second = first;
        Accept(ref first); Accept(ref second);
        Check(first == second && typeof(Box<dynamic>) == typeof(Box<object>), "dynamic-and-object-preserve-constructed-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
