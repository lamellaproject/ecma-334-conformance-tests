/*
Rules: E12-8-16-7-brace-form; E12-8-16-7-syntax; E12-8-16-7-anonymous-instance; E12-8-16-7-anonymous-type-declaration; E12-8-16-7-anonymous-class
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: var second = new { };
Into: var second = new { Marker = 7 };
*/
using System;
class Program
{
    static bool IsClass<T>(T value) where T : class { return value != null; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var first = new { };
        var second = new { };
        Check(IsClass(first), "empty-initializer-creates-class-instance");
        Check(!object.ReferenceEquals(first, second), "empty-anonymous-instances-distinct");
        first = second;
        Check(object.ReferenceEquals(first, second), "empty-initializers-share-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
